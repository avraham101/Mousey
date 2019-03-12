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
        private float middle_y = -1; //middle of the roller
        private float touch_y = -1; //the position the roller moved
        private float prev_touch_y = 0; //the pre position of the roller
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
            if (e.ActionMasked == MotionEventActions.Down || e.ActionMasked == MotionEventActions.Move)
            {
                setPostion(e.GetY());
                Invalidate();
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                resetPosition();
                Invalidate();
                return true;
            }

            return false;
        }
        protected override void DispatchDraw(Canvas canvas)
        {
            base.DispatchDraw(canvas);
            if (roller != null)
            {
                Paint p = createPaint(2, true, Xamarin.Forms.Color.FromHex("#D0D0D0"));
                Paint rollerp = createPaint(2, true, Xamarin.Forms.Color.Gray);//.FromHex("#D0D0D0"));
                Rect bounds = new Rect();
                canvas.GetClipBounds(bounds);
                canvas.DrawRoundRect(new RectF(bounds), 40, 40, rollerp);
                float mx = bounds.Width() / 2 - 1, my = bounds.Height() / 2 - 1;
                setMiddle(my);
                string print = printArrow();
                if (touch_y != 0)
                {
                    if (touch_y < bounds.Top + mx)
                        touch_y = bounds.Top + mx;
                    else if(touch_y > bounds.Bottom - mx)
                        touch_y = bounds.Bottom - mx;
                }
                canvas.DrawCircle(bounds.CenterX(), touch_y, mx-2, p);
                rollerp.TextSize = 40;
                rollerp.FakeBoldText = true;
                int distance_y = 40;
                canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14, rollerp);
                rollerp.SetARGB(255 , 6, 241, 77);
                canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14 - distance_y, rollerp);
                canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14 + distance_y, rollerp);
                
            }
        }

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
        
        //the function set the middle only in the first itteration 
        private void setMiddle(float middle)
        {
            //first time attempt set it in the middle
            if (middle_y == -1)
            {
                middle_y = middle;
                resetPosition();
            }
        }

        //the function reset the position of the roller
        private void resetPosition()
        {
            touch_y = middle_y;
            prev_touch_y = middle_y;
        }

        //the function set a new Position to the roller
        private void setPostion(float new_y)
        {
            prev_touch_y = touch_y;
            touch_y = new_y;
        }

        //the function return the string to print
        private String printArrow()
        {
            if (prev_touch_y > touch_y)
                return "↑";
            else if (prev_touch_y < touch_y)
                return "↓";
            return "";
        }

        //the function print the Arrows
        private void printRoller(Canvas canvas)
        {
            //Todo
            /*canvas.DrawCircle(bounds.CenterX(), touch_y, mx - 2, p);
            rollerp.TextSize = 40;
            rollerp.FakeBoldText = true;
            int distance_y = 40;
            canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14, rollerp);
            rollerp.SetARGB(255, 6, 241, 77);
            canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14 - distance_y, rollerp);
            canvas.DrawText(print, bounds.Left + mx - 19, touch_y + 14 + distance_y, rollerp);*/
        }
    }
}