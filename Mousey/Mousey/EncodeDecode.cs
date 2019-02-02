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

        public string decodeNextByte(byte b)
        {
            //Doto
            return null;
        }

        public byte[] encode(string msg)
        {
            //Doto
            return null;
        }

        public byte[] encode(Pair<double> p)
        {
            String msg = p.getFirst() + "f" + p.getSecond() + "s"; 
            return Encoding.ASCII.GetBytes(msg);
        }
    }
}
