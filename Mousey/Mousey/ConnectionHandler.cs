﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace Mousey
{
    class ConnectionHandler
    {
        private String url;
        private int port;
        private Boolean connected;
        private EncodeDecode encoder;
        private TcpClient client;
        //maybe in the future i want it to be in 2 threads, meanwhile its 1 thread to the client
        public Queue<String> messagesToSend; 

        public ConnectionHandler(String url,int port)
        {
            this.url = url;
            this.port = port;
            encoder = new EncodeDecode();
            connected = false;
            client = null;
        }

        public void StartConnection()
        {
            try
            {
                client = new TcpClient(url,port);
                connected = true;
            }
            catch(Exception e){
                //Do nothing yet
                //in the future need to be her logger
            }
        }

        public void sendMessage(Pair<double> msg)
        {
            if (isConnected())
            {
                byte[] arr = encoder.encode(msg);
                try
                {
                    Stream streamer = client.GetStream();
                    streamer.Write(arr, 0, arr.Length);
                    streamer.Flush();
                }
                catch (Exception e)
                {
                    //Do nothing yet
                    //in the future need to be her logger
                }
            }
        }

        public void reciveMessage()
        {
            //Not Yet Needed
            if(isConnected())
            {

            }
        }

        public Boolean isConnected()
        {
            return connected;
        }
    }
}
