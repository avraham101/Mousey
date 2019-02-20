using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Mousey;

namespace Mousey
{
    public class MovingSensor: Button
    {
        public MovingSensor() : base()
        {
            pointQueue = new Queue<Pair<float>>();
            vectorQueue = new Queue<Pair<float>>();
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        private float x =0;
        private float y =0;

        private Object pointSync = new Object();
        private Queue<Pair<float>> pointQueue;

        public void AddPoint(float x, float y)
        {
            lock (pointSync)
            {
                X = x;
                Y = y;
                pointQueue.Enqueue(new Pair<float>(x, y));
            }
        }
        public Pair<float> GetPoint()
        {
            lock (pointSync)
            {
                if (pointQueue.Count != 0)
                    return pointQueue.Dequeue();
                return null;
            }
        }


        private Object vectorSync = new Object();
        private Queue<Pair<float>> vectorQueue;

        public void AddVector(float x, float y)
        {
            lock (vectorSync)
            {
                vectorQueue.Enqueue(new Pair<float>(x, y));
            }
        }
        public Pair<float> GetVector()
        {
            lock (vectorSync)
            {
                if (vectorQueue.Count != 0)
                    return vectorQueue.Dequeue();
                return null;
            }
        }
        public void reset()
        {
            lock(pointSync)
            {
                pointQueue = new Queue<Pair<float>>();
            }
            lock(vectorSync)
            {
                vectorQueue = new Queue<Pair<float>>();
            }
        }

    }
}
