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
        ConnectionHandler handler;

        public MainPage()
        {
            InitializeComponent();
            binder = new MainBinder();
            handler = new ConnectionHandler("", -1);
            this.BindingContext = binder;
            binder.Label = "Nothing";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (binder.Conn == "On")
            {
                handler.changeCon(binder.Ip, Int32.Parse(binder.Port));
                //handler.StartConnection();
                binder.Conn = "Off";
                binder.DotColor = Color.FromHex("#27FC3E");
            }
            else
            {
                //handler.closeConnection();
                binder.Conn = "On";
                binder.DotColor = Color.FromHex("#FC0000");
            }
            //send data
            /*if (handler.isConnected())
            {
                Pair<double> msg = new Pair<double>(e.Values[0], e.Values[1]);
                handler.sendMessage(msg);
            }*/
        }
    }
}
