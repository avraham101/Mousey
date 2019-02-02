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

        private ObservableCollection<string> _pointsX;
        public ObservableCollection<string> PointsX
        {
            get
            {
                return _pointsX;
            }
            set
            {
                _pointsX = value;
                OnPropertyChanged("PointsX");
            }
        }
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

        public void AddPointX(string xpoint)
        {
            if (_pointsX.Count > 0)
            {
                if (_pointsX[_pointsX.Count - 1].CompareTo(xpoint) != 0)
                {
                    _pointsX.Add(xpoint);
                    OnPropertyChanged("PointsX");
                }
            }
            else
            {
                _pointsX.Add(xpoint);
                OnPropertyChanged("PointsX");
            }
            
        }
        public MainBinder()
        {
            _pointsX = new ObservableCollection<string>();
        }

        //The Method For the binding, Property Changed
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
