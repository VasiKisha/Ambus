# Ambus - Windows control application
PC sw application to control HW peripherals with custom serial communication protocol.

## Contains
- Ambus Terminal
- EchoRadar GUI

## Peripheral hardware
- [EchoRadar](https://github.com/VasiKisha/Ambus---EchoRadar)

## Protocol desctription
Ambus is a simple, easy to read, querry - response protocol. Data are transferred in ASCII format.

### Structure
**QUERRY:** $[ADDRESS];[COMMAND];[DATA - optional];[CHECKSUM]\n

**RESPONSE:** $[ADDRESS];[COMMAND];[DATA - optional];[CHECKSUM]\n

- ADDRESS:  1 - 8 characters
- COMMAND:  1 - 8 characters
- DATA:     0 - 32 characters
- CHECKSUM: 1 character
- max 54 characters per message

QUERRY must be allways confirmed by RESPONSE, even no data or command is required to send. RESPONSE from receiver means the message was successfull received.

### Reserved characters:
- $ (0x24) - start of message
- ; (0x3B) - separator (third separator not present in case no data)
- \n (0x0A) - end of message

### Checksum
```c#
            char sum = 0;
            foreach(char c in message)
            {
                sum = (sum + c) % 255;
            }
            return sum
```
If result of checksum is reserved character (0x24, 0x3B or 0x0A) then the checksum is substituted by 0x1A.
