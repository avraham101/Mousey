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
using Color = Xamarin.Forms.Color;

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
                var newc = new Color(back.R - 0.1, back.G - 0.1, back.B - 0.1);
                button.BackgroundColor = Color.Transparent;
                Invalidate();
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                //button.SendMessagge(true);
                button.BackgroundColor = back;
                Invalidate();
                return true;
            }
            return false;
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            //base.DispatchDraw(canvas);
            if (button != null) {
                var p = new Paint();
                Rect rect = new Rect();
                p.StrokeWidth = 1;

                p.AntiAlias = true;
                p.SetStyle(Paint.Style.Fill);
                p.TextSize = 35;
                System.Drawing.Color c = button.BackgroundColor;
                p.SetARGB(255, c.R, c.G, c.B);
                
                canvas.GetClipBounds(rect);
                canvas.DrawRoundRect(new RectF(rect), button.CornerRadius, button.CornerRadius, p);
                p.Color = Android.Graphics.Color.Blue;
                canvas.DrawText(button.Text2, rect.Left + 5, rect.Top + 40, p);
                p.Color = Android.Graphics.Color.Black;
                p.TextSize = 42;
                canvas.DrawText(button.Text, rect.Left - 26 * button.Text.Length + rect.Width(), rect.Bottom - 10, p);

            }
        }

        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}