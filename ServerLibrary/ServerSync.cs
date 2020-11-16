using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;                                                                                                   
using System.IO;
using System.Net;

namespace ServerLibrary
{
    /// <summary>
    /// This class implements the most basic TCP Server of the Echo Type.
    /// </summary>
    public class ServerSync : Server
    {
        public ServerSync(IPAddress IP, int port) : base(IP, port)
        {}

        protected override void AcceptClient()
        {
            TcpClient = TcpListener.AcceptTcpClient();
            byte[] buffer = new byte[Buffer_size];
            Stream = TcpClient.GetStream();
            BeginDataTransmission();
        }

        protected override void BeginDataTransmission()
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("Wpisz tekst, ktory serwer ma edytowac:\n");
            Stream.Write(sendBytes, 0, sendBytes.Length);

            Stream.ReadTimeout = 10000;
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int message_size = Stream.Read(buffer, 0, Buffer_size);

                   string text = System.Text.Encoding.UTF8.GetString(buffer, 0, message_size);

                    var converted = new string(text.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x)).ToArray());
                   
                    byte[] buffer_2 = System.Text.Encoding.UTF8.GetBytes(converted);
                    Stream.Write(buffer_2, 0, buffer_2.Length);

                }
                catch (IOException e)
                {
                    break;
                }
            }

        }
        /// <summary>
        /// Overrided comment.
        /// </summary>
        public override void Start()
        {
            Console.Write("Oczekiwanie na polaczenie... \n");
            StartListening();
            //transmission starts within the accept function
            AcceptClient();

        }
    }
}
