# tcp_socket
Repository containing python and c# code for a TCP/IP socket, developed with the purpose of establishing a communication between a computer and Hololens2.

## Configuration
Connect both the PC and Hololens to the same Wi-Fi network.
### Server side -- Computer
Set parameters inside `tcpserver.py`:

 - *HOST*: IP address of the server. Set to "0.0.0.0" to listen to accept any incoming connection.
 - *PORT*: desired communication port (non-privileged ports are > 1023).

### Client side -- Hololens2
Set parameters inside `tcpSocket.cs`:

 - *HOST*: IP address of the computer communicating with Hololens.
 - *PORT*: desired communication port (non-privileged ports are > 1023). 
	 **Must be the same chosen on the server side.**
