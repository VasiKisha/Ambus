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

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in address)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in command)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            packet[i++] = Checksum(packet);
            packet[i++] = Convert.ToByte(END_OF_PACKET);

            return packet;
        }

        public static byte[] GetPacket(string address, string command, string data)
        {
            int i = 0;
            byte[] packet = new byte[PACKET_SIZE];

            if (address.Length > ADDRESS_SIZE) address = address.Substring(0, ADDRESS_SIZE);
            if (command.Length > COMMAND_SIZE) command = command.Substring(0, COMMAND_SIZE);
            if (data.Length > DATA_SIZE) data = data.Substring(0, DATA_SIZE);

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in address)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in command)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            if (data != "")
            {
                foreach (char c in data)
                {
                    packet[i++] = Convert.ToByte(c);
                }
                packet[i++] = Convert.ToByte(SEPARATOR);
            }
            packet[i++] = Checksum(packet);

            packet[i++] = Convert.ToByte(END_OF_PACKET);

            return packet;
        }

        public static bool ValidatePacket(byte[] packet)
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

            byte[] temp = new byte[eop - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = packet[i];
            }

            if (packet[eop - 1] != Checksum(temp))
            {
                Debug.WriteLine("checksum is incorrect: {0}, {1}", packet[eop - 1], Checksum(temp));
                return false;
            }

            return true;
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

            if (packet[eop - 1] != Checksum(packet.Substring(0,eop-1)))
            {
                Debug.WriteLine("checksum is incorrect: {0:X}, {1:X}", Convert.ToByte(packet[eop - 1]), Convert.ToByte(Checksum(packet.Substring(0, eop - 1))));
                return false;
            }

            return true;
        }

        public static string GetAddress(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";

            int sep = 0;
            int position = 0;

            foreach(byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep = position;
                    break;
                }
                position++;
            }

            return Encoding.UTF8.GetString(packet, 1, sep - 1);
        }

        public static string GetAddress(string packet)
        {
            if (!ValidatePacket(packet)) return "";

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

        public static string GetCommand(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";

            int[] sep = new int[2];
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if(b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 2) break;
                }
                position++;
            }

            return Encoding.UTF8.GetString(packet, sep[0] + 1, sep[1] - sep[0] - 1);
        }

        public static string GetCommand(string packet)
        {
            if (!ValidatePacket(packet)) return "";

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

        public static string GetData(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";
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

            if (sep[2] == -1) return "";
            return Encoding.UTF8.GetString(packet, sep[1] + 1, sep[2] - sep[1] - 1);
        }

        public static string GetData(string packet)
        {
            if (!ValidatePacket(packet)) return "";
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

            if (sep[2] == -1) return "";
            return packet.Substring(sep[1] + 1, sep[2] - sep[1] - 1);
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
