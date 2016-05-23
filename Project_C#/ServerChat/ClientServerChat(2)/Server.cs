using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets; // инструменты для работы с сетью
using System.Threading; // инструменты для работы с потоками

namespace ClientServerChat
{
    class Server
    {
        public TcpListener Listener; // обьект принимаются TCP клиентов
        public List<ClientInfo> clients = new List<ClientInfo>();
        public List<ClientInfo> NewClient = new List<ClientInfo>();
        public static Server server;
        static System.IO.TextWriter Out;

        public Server(int Port, System.IO.TextWriter _Out)
        {
            Out = _Out;
            Server.server = this;

            // Создаем "слушателя" для указанного порта

            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его
        }

        // Работа с входящими клиентами
        public void Work()
        {
            Thread ClientListener = new Thread(ListnerClient);
            ClientListener.Start();
            while (true)
            {
                foreach (ClientInfo client in clients)
                {
                    if (client.isConnect)
                    {
                        NetworkStream stream = client.Client.GetStream();
                        while (stream.DataAvailable)
                        {
                            int ReadByte = stream.ReadByte();
                            if (ReadByte != -1)
                            {
                                client.byffer.Add((byte)ReadByte);
                            }

                            if (client.byffer.Count > 0)
                            {
                                Out.WriteLine("Resend");
                                foreach (ClientInfo otherClient in clients)
                                {
                                    byte[] msg = client.byffer.ToArray();
                                    client.byffer.Clear();
                                    foreach (ClientInfo _otherClient in clients)
                                    {
                                        if (_otherClient != client)
                                        {
                                            try
                                            {
                                                _otherClient.Client.GetStream().Write(msg, 0, msg.Length);
                                            }

                                            catch
                                            {
                                                _otherClient.isConnect = false;
                                                _otherClient.Client.Close();
                                            }
                                        }


                                    }
                                }
                            }
                        }
                    }
                }
            }

            clients.RemoveAll(delegate (ClientInfo C1)
            {
                if (!C1.isConnect)
                {
                    Server.Out.WriteLine("Client Disconect");
                    return true;
                }
                return false;
            });

            if (NewClient.Count > 0)
            {
                clients.AddRange(NewClient);
                NewClient.Clear();
            }
        }

        // Остановка Сервера
        ~Server()
        {
            //Если слушатель был создан 
            if (Listener != null)
            {
                //отсанавливаем его
                Listener.Stop();
            }
            foreach (ClientInfo client in clients)
            {
                client.Client.Close();
            }
        }

        static void ListnerClient()
        {

        }
    }




    class ClientInfo
    {
        public TcpClient Client; // ссылка на TCP клиент
        public List<byte> byffer = new List<byte>(); // все что передает клиент храниться здесь сначала, а потом передаем другим клиентам
        public bool isConnect;// флаг, в сети ли клиент
        public ClientInfo(TcpClient Сlient)
        {
            this.Client = Сlient;
            isConnect = true;
        }
    }
}


