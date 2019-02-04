using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mousey
{
    public class MainBinder: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Properties to what to see
        private String label ="";
        private String net = "";
        private String ip = "IP";
        private String port = "Port";
        private String conn = "Not Connected";

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
