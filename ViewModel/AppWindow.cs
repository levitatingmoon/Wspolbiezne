using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace ViewModel
{
    public class AppWindow : PropertyChange
    {
        public StartCommand startCommand { get; set; }
        public StopCommand stopCommand { get; set; }
        Model.DrawingData drawingData = new Model.DrawingData();
        public ObservableCollection<CircleDrawing> circleDrawings { get; set; }
        private int circleNumber;
        int sleepTime = 30;
        public bool moving { get; set; }
        public bool notMoving { get; set; }
        int radius = 20;

        public AppWindow()
        {
            this.startCommand = new StartCommand(this);
            this.stopCommand = new StopCommand(this);
            circleDrawings = new ObservableCollection<CircleDrawing>();
            moving = false;
            notMoving = true;
        }

        void Start()
        {
            drawingData.Start(circleNumber);
            PrepareCircleDrawings();
            ChangeMoving();
            new Thread(DrawingThread).Start();
        }

        void Stop()
        {
            ChangeMoving();
            drawingData.Stop();
        }

        void PrepareCircleDrawings()
        {
            circleDrawings.Clear();
            List<int> xlist = drawingData.GetX();
            List<int> ylist = drawingData.GetY();
            for (int i = 0; i < xlist.Count; i++)
            {
                circleDrawings.Add(new CircleDrawing(xlist[i], ylist[i], radius));
            }
        }

        void Draw()
        {
            List<int> xlist = drawingData.GetX();
            List<int> ylist = drawingData.GetY();
            for (int i = 0; i < circleDrawings.Count; i++)
            {
                circleDrawings[i].X = xlist[i];
                circleDrawings[i].Y = ylist[i];
            }
            
        }

        void DrawingThread()
        {
            while (moving)
            {
                Draw();
                Thread.Sleep(sleepTime);
            }
        }

        public int CircleNumber
        {

            get => circleNumber;
            set
            {
                if (value.Equals(circleNumber))
                    return;
                if (value < 0)
                    value = Math.Abs(value);
                circleNumber = value;
                RaisePropertyChanged(nameof(circleNumber));
            }
        }

        public void ButtonClick()
        {
            Start();
            RaisePropertyChanged(nameof(moving));
            RaisePropertyChanged(nameof(notMoving));
        }
        public void ButtonStopClick()
        {
            Stop();
            RaisePropertyChanged(nameof(moving));
            RaisePropertyChanged(nameof(notMoving));
        }

        void ChangeMoving()
        {
            moving = !moving;
            notMoving = !notMoving;
        }

    }
}
