using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mousey
{
    public class ExtraFrame: Frame
    {
        private int topR = 0;
        private int botR = 0;
        public int TopR
        {
            get { return topR; }
            set { topR = value; }
        }
        public int BotR
        {
            get { return botR; }
            set { botR = value; }
        }
    }
}
