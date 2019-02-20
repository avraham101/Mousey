using System;
using System.Collections.Generic;
using System.Text;

namespace Mousey
{
    class EncodeDecode
    {
        private static char end_message_byte = 'e';

        public EncodeDecode()
        {

        }

        public String decodeNextByte(byte b)
        {
            //Doto
            return null;
        }

        public byte[] encode(string msg)
        {
            //Doto
            return null;
        }

        public byte[] encode(Pair<float> p)
        {
            String msg = "m" + p.getFirst() + "f" + p.getSecond() + end_message_byte; 
            return Encoding.ASCII.GetBytes(msg);
        }

        public byte[] encode(Message t)
        {
            byte[] arr = new byte[3];
            switch(t)
            {
                case Message.LeftClickDown:
                    arr[0] = (byte)'l';
                    arr[1] = (byte)'d';
                        break;
                case Message.LeftClickUp:
                    arr[0] = (byte)'l';
                    arr[1] = (byte)'u';
                    break;
                case Message.RightClickDown:
                    arr[0] = (byte)'r';
                    arr[1] = (byte)'d';
                    break;
                case Message.RightClickUp:
                    arr[0] = (byte)'r';
                    arr[1] = (byte)'u';
                    break;
                case Message.Logout:
                    arr = new byte[2];
                    arr[0] = (byte)'o';
                    arr[1] = (byte)end_message_byte;
                    return arr;
            }
            arr[2] = (byte)end_message_byte;
            return arr;
        }

    }
}
