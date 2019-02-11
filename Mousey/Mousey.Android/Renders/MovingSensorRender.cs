using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Mousey;
using Mousey.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MovingSensor), typeof(MovingSensorRender))]
namespace Mousey.Droid
{
    public class MovingSensorRender : ButtonRenderer
    {
        private MovingSensor sensor;
        private bool firstTouch = true;
        private float dir_x = 0;
        private float dir_y = 0;
        public float DirX
        {
            get { return dir_x; }
        }
        public float DirY
        {
            get { return dir_y; }
        }

        public MovingSensorRender(Context context) : base(context)
        {
        }

        public override bool OnInterceptTouchEvent(MotionEvent e)
        {
            if (e.ActionMasked == MotionEventActions.Down)
            {
                Parent.RequestDisallowInterceptTouchEvent(true);
                return true;
            }
            return false;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.ActionMasked == MotionEventActions.Move || e.ActionMasked == MotionEventActions.Down)
            {
                if (firstTouch)
                {
                    sensor.X = e.GetX();
                    sensor.Y = e.GetY();
                    sensor.Text = DirX + " " + DirY;
                    firstTouch = false;
                }
                else
                {
                    dir_x = sensor.X - e.GetX();
                    dir_y = sensor.Y - e.GetY();
                    sensor.X = e.GetX();
                    sensor.Y = e.GetY();
                    sensor.Text = DirX+ " " + DirY;
                }
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                firstTouch = true;
                return true;
            }
            return false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement!=null)
            {
                sensor = (e.NewElement as MovingSensor);
            } 
        }

        protected void ChangeColor()
        {
            Control.SetBackgroundColor(global::Android.Graphics.Color.Red);
        }

    }
}

