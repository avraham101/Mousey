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
                //define the paint
                var p = new Paint();
                p.StrokeWidth = 1;
                p.AntiAlias = true;
                p.SetStyle(Paint.Style.Fill);
                System.Drawing.Color c = button.BackgroundColor;
                p.SetARGB(255, c.R, c.G, c.B);
                //define the place
                Rect rect = new Rect();
                canvas.GetClipBounds(rect);
                //draw back ground
                canvas.DrawRoundRect(new RectF(rect), button.CornerRadius, button.CornerRadius, p);
                //change paint to 2 design
                c = button.TextColor2;
                p.SetARGB(255, c.R, c.G, c.B);
                p.TextSize = (int)button.TextSize2;
                //draw 2 text
                canvas.DrawText(button.Text2, rect.Left + 5, rect.Top + p.TextSize, p);
                //change paint to 1 design
                c = button.TextColor;
                p.SetARGB(255, c.R, c.G, c.B);
                p.TextSize = (int)button.TextSize;
                //draw main text
                canvas.DrawText(button.Text, rect.Left - (button.TextSize/2) * button.Text.Length + rect.Width() - button.VerticalSpace, rect.Bottom - button.HorizonalSpace, p);
            }
        }

        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}