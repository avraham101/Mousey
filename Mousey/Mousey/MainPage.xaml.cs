using Android.Content;
using Android.Hardware;
using System;
using Xamarin.Forms;
using Android.App;
using System.Net.Sockets;
using System.IO;

namespace Mousey
{
    public partial class MainPage : ContentPage
    {
        MainBinder binder;
        Active1 action_handler;

        public MainPage()
        {
            InitializeComponent();
            binder = new MainBinder();
            action_handler = new Active1(binder);
            Client me = new Client(binder);
            this.BindingContext = binder;
        }

        private class Active1 : Activity, ISensorEventListener
        {
            MainBinder binder;
            Object syncer = new Object(); //locker to synchronzie
            SensorManager _sensorManager;

            ConnectionHandler handler;
            String url = "192.168.14.135";
            int port = 1250;
            public Active1(MainBinder binder)
            {
                this.binder = binder;
                startConnectetion();
                _sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
                _sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer)
                    , SensorDelay.Normal);
            }

            private void startConnectetion()
            {
                handler = new ConnectionHandler(url, port);
                handler.StartConnection();
            }

            void ISensorEventListener.OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
            {

            }

            void ISensorEventListener.OnSensorChanged(SensorEvent e)
            {
                lock (syncer)
                {
                    if (handler.isConnected())
                    {
                        binder.Label = string.Format("x={0:f}, y={1:f}, z={2:f}", (int)e.Values[0], (int)e.Values[1], (int)e.Values[2]);
                        Pair<double> msg = new Pair<double>(e.Values[0], e.Values[1]);
                        handler.sendMessage(msg);
                    }
                }
            }
        }
    }
}
