using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModel
{
    public class CircleDrawing : INotifyPropertyChanged
    {
        private int _x;
        public int X { 
            get { return _x; }
            set
            {
                _x = value - diameter/2;
                OnPropertyChanged("X");
            }
        }
        private int _y;
        public int Y {
            get { return _y; }
            set
            {
                _y = value - diameter/2;
                OnPropertyChanged("Y");
            }
        }
        //public int x { get; set; }
        //public int y { get; set; }
        public int diameter { get; set; }

        public CircleDrawing(int x, int y, int radius)
        {
            this.X = x - radius;
            this.Y = y - radius;
            diameter = radius * 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
