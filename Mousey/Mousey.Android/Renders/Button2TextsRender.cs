using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Mousey;
using Mousey.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button2Texts), typeof(Button2TextsRender))]
namespace Mousey.Droid
{
    public class Button2TextsRender : ButtonRenderer
    {
        private Button2Texts button;
        private System.Drawing.Color back;

        public Button2TextsRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                button = (e.NewElement as Button2Texts);
                back = button.BackgroundColor;
            }

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
                //button.SendMessagge(false);
                Color newc = new Color(back.R - 0.1, back.G - 0.1, back.B - 0.1);
                button.BackgroundColor = newc;
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                //button.SendMessagge(true);
                button.BackgroundColor = back;
                return true;
            }
            return false;
        }

        public override void Draw(Canvas canvas)
        {
            if (button != null) {
                var p = new Paint();
                p.AntiAlias = true;
                p.SetStyle(Paint.Style.Stroke);
                p.StrokeWidth = 5;
                p.Color = Android.Graphics.Color.Black;

                canvas.DrawText(button.Text2,canvas.get)
            base.Draw(canvas);
            }
        }
    }
}