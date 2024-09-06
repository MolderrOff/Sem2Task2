using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem2Task2
{
    internal class Server
    {
        public static void AcceptMsg()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16874);
            Console.WriteLine("Сервер ожидает сообщение");


            while (true)
            {
                byte[] buffer = udpClient.Receive(ref ep);
                string data = Encoding.UTF8.GetString(buffer);



                Thread tr = new Thread(() =>
                {
                    Message msg = Message.FromJson(data);
                    Console.WriteLine(msg.ToString());
                    Message responseMsg = new Message("Server", "Message accept on serv!");
                    string responseMsgJs = responseMsg.ToJson();
                    byte[] responseDate = Encoding.UTF8.GetBytes(responseMsgJs);
                    udpClient.Send(responseDate, responseDate.Length, ep); 



                });
                tr.Start();


                //1
                while (Console.ReadKey().Key != ConsoleKey.Escape) { tr.Join(); break; };
                Console.WriteLine("Нажмите клавишу <Esc> для выхода:");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)  //
                {

                    Console.WriteLine("Нажата Escape");
                    tr.Join();
                    break;

                };
                //2

            };


        }
    }
}
