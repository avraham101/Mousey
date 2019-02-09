﻿using Android.Content;
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
            this.BindingContext = binder;
            binder.Label = "Nothing";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            action_handler.Start(binder.Ip,Int32.Parse(binder.Port));
            binder.Conn = "Connected";
        }

        private class Active1 : Activity, ISensorEventListener 
        {
            MainBinder binder;
            Object syncer = new Object(); //locker to synchronzie
            SensorManager _sensorManager;

            ConnectionHandler handler;
            public Active1(MainBinder binder)
            {
                this.binder = binder;
                init();
                _sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
                //_sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Fastest);
                //_sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.), SensorDelay.Fastest);
                //_sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Gyroscope), SensorDelay.Fastest);
                //_sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.LinearAcceleration), SensorDelay.Fastest);
            }

            private void init()
            {
                handler = new ConnectionHandler("", -1);
            }

            public void Start(String url,int port)
            {
                handler.changeCon(url, port);
                handler.StartConnection();
            }

            void ISensorEventListener.OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
            {
            }

            //the x
            void ISensorEventListener.OnSensorChanged(SensorEvent e)
            {
                switch(e.Sensor.Type)
                {
                    case SensorType.Accelerometer:
                    case SensorType.LinearAcceleration:
                    case SensorType.Gyroscope:
                        binder.Label = string.Format("x={0:f}, y={1:f}, z={2:f}", e.Values[0], e.Values[1], e.Values[2]);
                        lock (syncer)
                        {
                            if (handler.isConnected())
                            {
                                Pair<double> msg = new Pair<double>(e.Values[0], e.Values[1]);
                                handler.sendMessage(msg);
                            }
                        }
                    break;
                }
            }
        }
    }
}