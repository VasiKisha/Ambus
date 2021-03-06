//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Text;
using System.Diagnostics;

namespace AMBUS_Master
{
    public static class Ambus
    {
        private static string myAddress = "MASTER";
        public const char START_OF_PACKET = '$';
        public const char SEPARATOR = ';';
        public const char END_OF_PACKET = '\n';
        public const byte SUBSTITUTE = 0x1A;
        public const int ADDRESS_SIZE = 8;
        public const int COMMAND_SIZE = 8;
        public const int DATA_SIZE = 32;
        public const int CRC_SIZE = 1;
        public const int PACKET_SIZE = ADDRESS_SIZE + COMMAND_SIZE + DATA_SIZE + CRC_SIZE + 5;

        public enum CRCFormat
        {
            RawCRC,
            NoCRC,
            HexCRC,
        }

        public static void SetMyAddress(string address)
        {
            myAddress = address;
        }

        public static string GetMyAddress()
        {
            return myAddress;
        }

        public static byte[] GetPacket(string address, string command)
        {
            int i = 0;
            byte[] packet = new byte[PACKET_SIZE];

            if (address.Length > ADDRESS_SIZE) address = address.Substring(0, ADDRESS_SIZE);
            if (command.Length > COMMAND_SIZE) command = command.Substring(0, COMMAND_SIZE);

            byte[] baddress = new byte[address.Length];
            baddress = Encoding.GetEncoding(28591).GetBytes(address);
            byte[] bcommand = new byte[command.Length];
            bcommand = Encoding.GetEncoding(28591).GetBytes(command);

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in baddress)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in bcommand)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            packet[i++] = Checksum(packet);
            packet[i++] = Convert.ToByte(END_OF_PACKET);

            if (ValidatePacket(packet)) return packet;
            else return null;
        }

        public static byte[] GetPacket(string address, string command, string data)
        {
            int i = 0;

            byte[] packet = new byte[PACKET_SIZE];

            if (address.Length > ADDRESS_SIZE) address = address.Substring(0, ADDRESS_SIZE);
            if (command.Length > COMMAND_SIZE) command = command.Substring(0, COMMAND_SIZE);
            if (data.Length > DATA_SIZE) data = data.Substring(0, DATA_SIZE);

            byte[] baddress = new byte[address.Length];
            baddress = Encoding.GetEncoding(28591).GetBytes(address);
            byte[] bcommand = new byte[command.Length];
            bcommand = Encoding.GetEncoding(28591).GetBytes(command);
            byte[] bdata = new byte[data.Length];
            bdata = Encoding.GetEncoding(28591).GetBytes(data);

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in baddress)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in bcommand)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            if (data != "")
            {
                foreach (char c in bdata)
                {
                    packet[i++] = Convert.ToByte(c);
                }
                packet[i++] = Convert.ToByte(SEPARATOR);
            }
            packet[i++] = Checksum(packet);
            packet[i++] = Convert.ToByte(END_OF_PACKET);

            if (ValidatePacket(packet)) return packet;
            else return null;
        }

        public static int GetPacketLength(byte[] packet)
        {
            if (packet == null) return 0;
            int eopPos = 0;     //end of packet postition
            foreach (byte b in packet)
            {
                eopPos++;
                if (b == Convert.ToByte(Ambus.END_OF_PACKET)) break;
            }

            return eopPos;
        }

        public static bool ValidatePacket(byte[] bpacket)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return ValidatePacket(packet);
        }

        public static bool ValidatePacket(string packet)
        {
            int sop = -1, eop = -1;
            int[] sep = new int[3];
            sep[0] = -1;
            sep[1] = -1;
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (char b in packet)
            {
                if (b == START_OF_PACKET)
                {
                    if (sop != -1) return false;
                    sop = position;
                }
                if (b == SEPARATOR)
                {
                    if (isep > 2) return false;
                    sep[isep++] = position;
                }
                if (b == END_OF_PACKET)
                {
                    if (eop != -1) return false;
                    eop = position;
                }
                position++;
                //Debug.WriteLine("{0:X}",Convert.ToByte(b));
            }

            //Debug.WriteLine("Validation: ");
            //Debug.WriteLine("Start of packet position: {0}", sop);
            //Debug.WriteLine("Separator position: {0}, {1}, {2}", sep[0], sep[1], sep[2]);
            //Debug.WriteLine("End of packet position: {0}", eop);

            if (sop != 0) return false;
            if (sep[0] - sop < 2) return false;
            if (sep[1] - sep[0] < 2) return false;

            if (sep[2] == -1)   //no data
            {
                if (eop - sep[1] != 2) return false;
            }
            else                //with data
            {
                if (sep[2] - sep[1] < 2) return false;
                if (eop - sep[2] != 2) return false;
            }

            if (packet[eop - 1] != Checksum(packet.Substring(0, eop - 1)))
            {
                //Debug.WriteLine("checksum is incorrect: {0:X}, {1:X}", Convert.ToByte(packet[eop - 1]), Convert.ToByte(Checksum(packet.Substring(0, eop - 1))));
                return false;
            }

            //Debug.WriteLine("checksum is correct: {0:X}, {1:X}", Convert.ToByte(packet[eop - 1]), Convert.ToByte(Checksum(packet.Substring(0, eop - 1))));
            return true;
        }

        public static string GetAddress(byte[] bpacket)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return GetAddress(packet);
        }

        public static string GetAddress(string packet)
        {
            if (!ValidatePacket(packet)) return null;

            int sep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep = position;
                    break;
                }
                position++;
            }

            return packet.Substring(1, sep - 1);
        }

        public static string GetCommand(byte[] bpacket)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return GetCommand(packet);
        }

        public static string GetCommand(string packet)
        {
            if (!ValidatePacket(packet)) return null;

            int[] sep = new int[2];
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 2) break;
                }
                position++;
            }

            return packet.Substring(sep[0] + 1, sep[1] - sep[0] - 1);
        }

        public static string GetData(string packet)
        {
            if (!ValidatePacket(packet)) return null;
            int[] sep = new int[3];
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 3) break;
                }
                position++;
            }

            if (sep[2] == -1) return null;
            return packet.Substring(sep[1] + 1, sep[2] - sep[1] - 1);
        }

        public static string GetData(byte[] bpacket)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return GetData(packet);
        }

        public static string GetCRC(string packet)
        {
            if (!ValidatePacket(packet)) return null;
            int lastSep = 0;
            int position = 0;
            foreach(char c in packet)
            {
                if (c==SEPARATOR)
                {
                    lastSep = position;
                }
                position++;
            }
            return packet.Substring(lastSep + 1, 1);
        }

        public static string GetCRC(byte[] bpacket)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return GetCRC(packet);
        }

        public static string ParsePacket(byte[] bpacket, CRCFormat crcFormat)
        {
            string packet = Encoding.GetEncoding(28591).GetString(bpacket);
            return ParsePacket(packet, crcFormat);
        }

        public static string ParsePacket(string packet, CRCFormat crcFormat)
        {
            string address = GetAddress(packet);
            string command = GetCommand(packet);
            string data = GetData(packet);
            string crc = GetCRC(packet);

            if (address == null || command == null || crc == null) return packet;

            if (crcFormat == CRCFormat.RawCRC)
            {
                if (data == null)
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + crc + END_OF_PACKET;
                }
                else
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + data + SEPARATOR + crc + END_OF_PACKET;
                }
            }
            else if (crcFormat == CRCFormat.NoCRC)
            {
                if (data == null)
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + END_OF_PACKET;
                }
                else
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + data + SEPARATOR + END_OF_PACKET;
                }
            }
            else if (crcFormat == CRCFormat.HexCRC)
            {
                if (data == null)
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + "{0x" + Convert.ToByte(crc[0]).ToString("X2") + "}" + END_OF_PACKET;
                }
                else
                {
                    return START_OF_PACKET + address + SEPARATOR + command + SEPARATOR + data + SEPARATOR + "{0x" + Convert.ToByte(crc[0]).ToString("X2") + "}" + END_OF_PACKET;
                }
            }
            else return packet;
        }

        public static string PacketToString(byte[] bpacket)
        {
            return Encoding.GetEncoding(28591).GetString(bpacket);
        }

        private static byte Checksum(byte[] data)
        {
            int sum = 0;

            foreach (byte b in data)
            {
                sum = (sum + b) % 255;
            }

            if (sum == Convert.ToByte(START_OF_PACKET) || sum == Convert.ToByte(SEPARATOR) || sum == Convert.ToByte(END_OF_PACKET))
            {
                sum += 0x80;
            }
            return (byte)sum;
        }

        private static char Checksum(string data)
        {
            int sum = 0;

            foreach(char b in data)
            {
                sum = (sum + b) % 255;
            }

            if (sum == Convert.ToByte(START_OF_PACKET) || sum == Convert.ToByte(SEPARATOR) || sum == Convert.ToByte(END_OF_PACKET))
            {
                sum += 0x80;
            }
            return Convert.ToChar(sum);
        }
    }
}
