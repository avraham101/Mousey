using System;
using Xamarin.Forms;
using System.Threading;
namespace Mousey
{
    public partial class MainPage : ContentPage
    {
        MainBinder binder;
        ConnectionHandler handler;
        Thread sendTask;

        public MainPage()
        {
            InitializeComponent();
            binder = new MainBinder();
            handler = new ConnectionHandler("", -1);
            this.BindingContext = binder;
            binder.Label = "Nothing";
            sendTask = new Thread(SendData);
            //Mouse Buttons
            MouseLeftButton.SetHandler(handler);
        }

        public void Close()
        {
            handler.CloseConnection();
        }
        //On Button Click
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (binder.Conn == "On")
            {
                MoveGrid.reset();
                handler.changeCon(binder.Ip, Int32.Parse(binder.Port));
                handler.StartConnection();
                sendTask.Start();
                binder.Conn = "Off";
                binder.DotColor = Color.FromHex("#27FC3E");
            }
            else
            {
                handler.CloseConnection();
                sendTask.Abort();
                sendTask = new Thread(SendData);
                binder.Conn = "On";
                binder.DotColor = Color.FromHex("#FC0000");
            }
           
        }

        private void SendData()
        {
            try
            {
                while (handler.isConnected())
                {
                    Pair<float> p = MoveGrid.GetVector();
                    if (p != null)
                        handler.sendMessage(p);
                }
            }
            catch(Exception e)
            {

            }
        }
        
        //Mouse Click Left
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (sender != null)
            {
                handler.sendMessage(Message.LeftClickDown);
                handler.sendMessage(Message.LeftClickUp);
            }
        }
        
        //Mouse Click Right
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (sender != null)
            {
                handler.sendMessage(Message.RightClickDown);
                handler.sendMessage(Message.RightClickUp);
            }
        }
        
        //Change KeyBoard Mouse Click
        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if (sender != null)
            {
                binder.MouseOn = !binder.MouseOn;
            }
        }

        private void KeyBoard_Clicked(object sender, EventArgs e) {

        }
    }
}
