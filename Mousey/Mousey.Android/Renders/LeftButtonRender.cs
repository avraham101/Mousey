using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Mousey;
using Mousey.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LeftButton), typeof(LeftButtonRender))]
namespace Mousey.Droid
{
    public class LeftButtonRender : ButtonRenderer
    {
        private LeftButton button;
       
        public LeftButtonRender(Context context) : base(context)
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
            if (e.ActionMasked == MotionEventActions.Down)
            {
                button.SendMessagge(false);
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                button.SendMessagge(true);
                return true;
            }
            return false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement!=null)
                button = (e.NewElement as LeftButton);
             
        }
    }
}

