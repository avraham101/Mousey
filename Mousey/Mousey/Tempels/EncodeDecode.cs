using System;
using System.Collections.Generic;
using System.Text;

namespace Mousey
{
    class EncodeDecode
    {
        //Need to make this ninterface

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
            String msg = p.getFirst() + "f" + p.getSecond() + "s"; 
            return Encoding.ASCII.GetBytes(msg);
        }
    }
}
