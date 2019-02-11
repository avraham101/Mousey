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
        private String ip = "10.0.0.16";
        private String port = "1250";
        private String conn = "On";
        private Color dotcolor = Color.FromHex("#FC0000");
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
