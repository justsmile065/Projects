using UnityEngine;
using System.Collections;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;

public class Client
{
    static TcpClient client;

    public Client(int port, string connectIP)
    {
        
        client = new TcpClient();
        Client.(IPAddress.Parse(connectIP), port);
    }

    public void work()
    {
        Thread clientListener = new Thread(Reader);
        clientListener.Start();
    }

    public void SendMessage(string message)
    {
        message.Trim();
        byte[] buffer = Encoding.ASCII.GetBytes((message).ToCharArray());
        client.GetStream().Write(buffer, 0, buffer.Length);
        Chat.message.Add(message);
    }

    static void Reader()
    {
        while(true)
        {
            NetworkStream NS = client.GetStream();
            List<byte> buffer = new List<byte>();
            while (NS.DataAvailable)
            {
                int ReadByte = NS.ReadByte();
                if (ReadByte > -1)
                {
                    buffer.Add(byte)ReadByte);
                }
            }

            if (buffer.Count > 0)
                Chat.message.Add(Encoding.ASCII.GetString(buffer.ToArray()));
        }
    }

    ~Client()
    {
        if ( client != null)
        {
            client.Close();
        }
    }
}

