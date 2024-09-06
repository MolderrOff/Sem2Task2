using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sem2Task2
{
    class Client
    {
        public static void SendMsg(string name, int numberOfThread)//        public static void SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);
            UdpClient udpClient = new UdpClient();
            string doubleString =  numberOfThread.ToString() + " Привет";
            Message msg = new Message(name, doubleString);//            Message msg = new Message(name,  "Привет");
            string responseMsgJs = msg.ToJson();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            udpClient.Send(responseData, responseData.Length, ep); // я добавил
            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(answerData);
            Message answerMsg = Message.FromJson(answerMsgJs);
            Console.WriteLine(answerMsg.ToString());
            //Console.Write("Нажмите любую клавишу для выхода:");
            //Console.ReadLine();
        }


        
    }
}
