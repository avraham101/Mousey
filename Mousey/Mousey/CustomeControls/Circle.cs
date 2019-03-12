using Xamarin.Forms;

namespace Mousey
{
    public class Circle : BoxView
    {
        private Color insideColor;
        public Color CircleColor
        {
            set { insideColor = value; }
            get { return insideColor; }
        }
        public Circle() : base()
        {

        }
    }
}
