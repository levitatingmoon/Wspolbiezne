using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace ViewModel
{
    public class AppWindow
    {
        public StartCommand startCommand { get; set; }
        public StopCommand stopCommand { get; set; }
        Model.DrawingData drawingData = new Model.DrawingData();
        public ObservableCollection<CircleDrawing> circleDrawings { get; set; }
        int n = 3;
        int sleepTime = 30;
        bool moving = false;
        int radius = 20;

        public AppWindow()
        {
            this.startCommand = new StartCommand(this);
            this.stopCommand = new StopCommand(this);
            circleDrawings = new ObservableCollection<CircleDrawing>();
        }

        void Start()
        {
            drawingData.Start(n);
            PrepareCircleDrawings();
            moving = true;
            new Thread(DrawingThread).Start();
        }

        void Stop()
        {
            moving = false;
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

        public void PreviewTextInput()
        {

        }

        public void ButtonClick()
        {
            Start();
        }
        public void ButtonStopClick()
        {
            Stop();
        }


    }
}
