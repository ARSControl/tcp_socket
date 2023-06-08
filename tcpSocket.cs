using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class tcpSocket : MonoBehaviour
{
    private const int bufferSize = 1024;
    private const string serverIP = "192.168.1.12";
    private const int port = 12345;

    // Start is called before the first frame update
    void Start()
    {
        /* 
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
        serverSocket.Listen(10);
        Debug.Log("Server started. Waiting for incoming connections");
        Socket clientSocket = serverSocket.Accept();
        Debug.Log("Client connected");
        */

        try
        {
            // Create tcp/ip socket
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // connect to server
            clientSocket.Connect(IPAddress.Parse(serverIP), port);
            Debug.Log("Connected to server.");

            // send data to server
            string msg = "Hello, server.";
            byte[] msgBytes = Encoding.ASCII.GetBytes(msg);
            clientSocket.Send(msgBytes);
            Debug.Log("Sent msg");

            // receive data from server
            byte[] buffer = new byte[bufferSize];
            int bytesRead = clientSocket.Receive(buffer);
            string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Debug.Log("Received msg: " + receivedMessage);

            // close socket
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            
        }
        catch (Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
