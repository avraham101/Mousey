using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mousey
{
    public class Roller: BoxView 
    {
        private String dir = "None";
        public String Dir
        {
            set { dir = value; }
            get { return dir; }
        }

        private double speed;
        public double Speed
        {
            set { speed = value; }
            get { return speed; }
        }
    }
}
