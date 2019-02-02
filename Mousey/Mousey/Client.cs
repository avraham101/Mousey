using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Java.Net;

namespace Mousey
{
    public class Client
    {
        private int port=433;
        private string host= "10.0.0.8";
        private MainBinder binder;

        public Client(MainBinder binder)
        {
            this.binder = binder;
        }
    }
}
