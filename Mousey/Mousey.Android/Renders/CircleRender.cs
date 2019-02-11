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

[assembly: ExportRenderer(typeof(Circle), typeof(CircleRender))]
namespace Mousey.Droid
{
    public class CircleRender : BoxRenderer
    {
        private Circle circle=null;

        public CircleRender(Context t) : base (t)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Invalidate();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if(circle==null)
                circle = e.NewElement as Circle;
        }

        public override void Draw(Canvas canvas)
        {
            if (circle != null)
            {
                var p = new Paint();
                var backp = new Paint();

                p.AntiAlias = true;
                p.SetStyle(Paint.Style.Stroke);
                p.StrokeWidth = 5;
                p.Color = Android.Graphics.Color.Black;

                backp.SetStyle(Paint.Style.Fill);
                backp.StrokeWidth = 4;
                System.Drawing.Color c = circle.BackgroundColor;
                backp.SetARGB(255,c.R,c.G,c.B);

                Rect oldBounds = new Rect();
                canvas.GetClipBounds(oldBounds);
                float mx, my, raduis;
                mx = (float)oldBounds.CenterX();
                my = (float)oldBounds.CenterY();
                raduis = oldBounds.Height() / 2;
                if (oldBounds.Width() / 2 < oldBounds.Height() / 2)
                    raduis = oldBounds.Width() / 2;
                canvas.DrawCircle(mx, my, raduis, p);
                canvas.DrawCircle(mx, my, raduis, backp);
            }
        }
    }
}