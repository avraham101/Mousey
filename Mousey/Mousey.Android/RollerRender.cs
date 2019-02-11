﻿using System;
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
using Android.Widget;
using Mousey;
using Mousey.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ExportRenderer(typeof(Roller), typeof(RollerRender))]
namespace Mousey.Droid
{
    public class RollerRender: BoxRenderer
    {
        private Roller roller;
        private float touch_y = 0;

        public RollerRender(Context t) : base(t)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if(roller == null) 
                roller = e.NewElement as Roller;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Invalidate();
        }

        public override bool OnInterceptTouchEvent(MotionEvent e)
        {
            if (e.ActionMasked == MotionEventActions.Move || e.ActionMasked == MotionEventActions.Down)
            {
                touch_y = e.GetY();
                Invalidate();
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                touch_y = 0;
                Invalidate();
                return true;
            }
            return false;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.ActionMasked == MotionEventActions.Move || e.ActionMasked == MotionEventActions.Down)
            {
                touch_y = e.GetY();
                Invalidate();
                return true;
            }
            if (e.ActionMasked == MotionEventActions.Up)
            {
                touch_y = 0;
                Invalidate();
                return true;
            }
            return false;
        }

        public override void Draw(Canvas canvas)
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
                        my = touch_y;
                }
                DrawCircle(canvas, bounds.CenterX(), bounds.CenterY(), mx, my, backp);
                DrawCircle(canvas, bounds.CenterX(), bounds.CenterY(), mx, my, p);
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

        private void DrawCircle(Canvas c,float mx, float my, float rx, float ry, Paint p)
        {
            if(rx<ry)
                c.DrawCircle(mx, my, rx, p);
            else
                c.DrawCircle(mx, my, ry, p);
        }
    }
}