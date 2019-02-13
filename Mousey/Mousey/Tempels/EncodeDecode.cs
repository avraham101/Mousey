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
            byte[] arr = new byte[2];
            arr[0] = (byte)encodeByte(t);
            arr[1] = (byte)end_message_byte;
            return arr;
        }

        public char encodeByte(Message t)
        {
            switch(t)
            {
                case Message.LeftClick: return 'l';
                case Message.RightClick: return 'r';
                case Message.Movment: return 'm';
            }
            return 'n';
        }
    }
}
