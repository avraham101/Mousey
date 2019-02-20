using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace Mousey
{
    public class ConnectionHandler
    {
        private String url;
        private int port;
        private Boolean connected;
        private EncodeDecode encoder;
        private TcpClient client;
        private Object tasksync = new object();

        public ConnectionHandler(String url,int port)
        {
            this.url = url;
            this.port = port;
            encoder = new EncodeDecode();
            connected = false;
            client = null;
        }

        //start the conection handler. Open socket
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

        //change the connected value
        public void CloseConnection(){
            lock (tasksync)
            {
                sendMessage(Message.Logout);
                if (connected)
                    connected = false;
                client.Close();
                client.Dispose();
            }
        }

        //Movment Change send to the server
        public void sendMessage(Pair<float> msg)
        {
            lock (tasksync)
            {
                if (isConnected())
                {
                    byte[] arr = encoder.encode(msg);
                    sendMessage(arr);
                }
            }
        }

        //Right Click or Left Click send to the server
        public void sendMessage(Message t)
        {

            lock (tasksync)
            {
                if (isConnected())
                {
                    byte[] arr = encoder.encode(t);
                    sendMessage(arr);
                }
            }
        }

        //help function send data to the server
        private void sendMessage(byte[] arr)
        {
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

        //Not Yet Implemented
        public void reciveMessage()
        {
            //Not Yet Needed
            if(isConnected())
            {

            }
        }

        //check if the connection handler connected
        public Boolean isConnected()
        {
            return connected;
        }

        //change the connection with spasific port and url
        public void changeCon(String url,int port)
        {
            this.url = url;
            this.port = port;
        }
    }
}
