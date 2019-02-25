using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Mousey
{
    public class MainBinder: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Properties to what to see
        private String label ="";
        private String net = "";
        private String ip = "192.168.14.135";//"10.0.0.16";
        private String port = "1250";
        private String conn = "On";
        private Color dotcolor = Color.FromHex("#FC0000");
        private Boolean mouseOn = true; //if mouse on = false means show keyboard else show mouse
        public String Label
        {
            get { return label; }
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }
        public String Net
        {
            get { return net; }
            set
            {
                net = value;
                OnPropertyChanged("Label");
            }
        }
        public String Ip
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }
        public String Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }
        public String Conn
        {
            get
            {
                return conn;
            }
            set
            {
                conn = value;
                OnPropertyChanged("Conn");
            }
        }
        public Color DotColor
        {
            get
            {
                return dotcolor;
            }
            set
            {
                dotcolor = value;
                OnPropertyChanged("DotColor");
            }
        }
        public Boolean MouseOn
        {
            get
            {
                return mouseOn;
            }
            set
            {
                mouseOn = value;
                OnPropertyChanged("MouseOn");
                OnPropertyChanged("KeyBoardOn");
                OnPropertyChanged("FetureText");
            }
        }
        public Boolean KeyBoardOn
        {
            get
            {
                return !mouseOn;
            }
            set
            {
                mouseOn = !value;
                OnPropertyChanged("MouseOn");
                OnPropertyChanged("KeyBoardOn");
                OnPropertyChanged("FetureText");
            }
        }
        public String FetureText
        {
            set { }
            get
            {
                if (MouseOn)
                    return "KeyBoard";
                return "Mouse"; 
            }
        }
        public MainBinder()
        {
        }

        //The Method For the binding, Property Changed
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
