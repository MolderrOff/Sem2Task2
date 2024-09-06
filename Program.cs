using System;
using System.Threading;

namespace Sem2Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server.AcceptMsg();
                
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread trClient = new Thread(() =>
                    {
                        Client.SendMsg(args[0], i);

                    });
                    trClient.Start();


                    Console.WriteLine("Нажмите <Exit> для выхода:");
                    string endProg = Console.ReadLine();

                    if (endProg == "Exit")
                    {
                        trClient.Join();
                        break;
                    }


                }


            }


        }
    }
}
