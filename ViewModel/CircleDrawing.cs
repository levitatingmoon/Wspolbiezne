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
                _x = value;
                OnPropertyChanged("X");
            }
        }
        private int _y;
        public int Y {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
        public int diameter { get; set; }

        public CircleDrawing(int x, int y, int radius)
        {
            this._x = x - radius;
            this._y = y - radius;
            diameter = radius * 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
