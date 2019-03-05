using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mousey
{
    public class Button2Texts : Button
    {
        private String text2;
        private Color textColor2;
        private int textSize;
        private int textSize2;
        private int verticalSpace=5;
        private int horizonalSpace=5;
        public String Text2
        {
            get { return text2; }
            set { text2 = value; }
        }
        public Color TextColor2
        {
            set { textColor2 = value; }
            get { return textColor2; }
        }
        public int TextSize
        {
            set { textSize = value; }
            get { return textSize; }
        }
        public int TextSize2
        {
            set { textSize2 = value; }
            get { return textSize2; }
        }
        public int VerticalSpace
        {
            set { verticalSpace = value; }
            get { return verticalSpace; }
        }
        public int HorizonalSpace
        {
            set { horizonalSpace = value; }
            get { return horizonalSpace; }
        }
        public Button2Texts():base()
        {

        }

    }
}
