import socket

HOST = "0.0.0.0"  # Standard loopback interface address (localhost)
PORT = 12345  # Port to listen on (non-privileged ports are > 1023)

print("Ciao")
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind((HOST, PORT))
server_socket.listen(1)


print("Waiting for client...")

cl_socket, cl_add = server_socket.accept()
print("Client connected", cl_add)

while True:
    data = cl_socket.recv(1024).decode()
    if not data:
        break

    print("Received from cleint:", data)

    resp = "Response from server: " + data.upper()
    cl_socket.send(resp.encode())

cl_socket.close()
server_socket.close()