using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Mousey;
using Mousey.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ExportRenderer(typeof(Roller), typeof(RollerRender))]
namespace Mousey.Droid
{
    public class RollerRender: ButtonRenderer
    {
        private Roller roller;
        private float touch_y = 0;

        public RollerRender(Context t) : base(t)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(roller == null) 
                roller = e.NewElement as Roller;
            Invalidate();
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
                touch_y = e.GetY();
                //ChangeColor();
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                return true;
            }
            return false;
        }

        /*protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            if(roller!=null)
            {
                Paint p = createPaint(2, false, Xamarin.Forms.Color.Black);
                Paint rollerp = createPaint(2, true, Xamarin.Forms.Color.FromHex("#D0D0D0"));
                Paint backp = createPaint(4, true, roller.BackgroundColor);
                Rect bounds = new Rect();
                canvas.GetClipBounds(bounds);
                canvas.DrawRoundRect(new RectF(bounds), 10, 40, rollerp);
                float mx = bounds.Width() / 2 - 1, my = bounds.Height() / 2 -1 ; 
                if (touch_y!=0)
                {
                    if (touch_y < bounds.Top & touch_y > bounds.Bottom)
                    {
                        my = touch_y;
                        roller.Text = "Here";
                    }
                }
                DrawCircle(canvas, bounds.CenterX(), bounds.CenterY(), mx, my, backp);
                DrawCircle(canvas, bounds.CenterX(), bounds.CenterY(), mx, my, p);
            }
            return true;
        }*/

        private Paint createPaint(int width,bool StyleFillorStroke, Xamarin.Forms.Color color)
        {
            Paint p = new Paint();
            p.AntiAlias = true;
            p.SetStyle(Paint.Style.Stroke);
            if (StyleFillorStroke)
                p.SetStyle(Paint.Style.Fill);
            p.StrokeWidth = width;
            p.Color = color.ToAndroid();
            return p;
        }

        private void DrawCircle(Canvas c,float mx, float my, float rx, float ry, Paint p)
        {
            if(rx<ry)
                c.DrawCircle(mx, my, rx, p);
            else
                c.DrawCircle(mx, my, ry, p);
        }

        protected void ChangeColor()
        {
            Control.SetBackgroundColor(global::Android.Graphics.Color.Red);
        }

    }
}