# Ambus - Windows control application
PC sw application to control HW peripherals with custom serial communication protocol.

## Protocol desctription
Ambus is a simple, easy to read, querry - response protocol. Data are transferred in ASCII format.

### Structure
QUERRY: $[ADDRESS];[COMMAND];[DATA - optional];[CHECKSUM]\n

RESPONSE: $[ADDRESS];[COMMAND];[DATA - optional];[CHECKSUM]\n

- ADDRESS:  1 - 8 characters
- COMMAND:  1 - 8 characters
- DATA:     0 - 32 characters
- CHECKSUM: 1 character
- max 54 characters per message

QUERRY must be allways confirmed by RESPONSE, even no data or command is required to send. RESPONSE from receiver means the message was successfull received.

### Reserved characters:
- $ - start of message
- ; - separator (third separator not present in case no data)
- \n - end of message

### Checksum
