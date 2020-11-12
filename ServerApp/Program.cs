using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new ServerSync(IPAddress.Parse("127.0.0.1"), 3000);
            server.Start();

        }
    }
}
