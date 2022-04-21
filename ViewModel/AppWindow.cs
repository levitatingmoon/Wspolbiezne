using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace ViewModel
{
    public class AppWindow
    {
        public StartCommand startCommand;
        Model.DrawingData drawingData = new Model.DrawingData();
        ObservableCollection <CircleDrawing> circleDrawings = new ObservableCollection<CircleDrawing>();
        int n = 5;
        int sleepTime = 100;
        bool moving = false;
        int radius = 10;

        public AppWindow()
        {
            this.startCommand = new StartCommand(this);
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
                circleDrawings[i].SetX(xlist[i]);
                circleDrawings[i].SetY(ylist[i]);
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

        }

    }
}
