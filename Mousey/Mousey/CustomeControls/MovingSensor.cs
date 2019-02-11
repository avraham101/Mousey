using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mousey
{
    public class MovingSensor: Button
    {
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        private float x =0;
        private float y =0;
    }
}
