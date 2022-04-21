using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class Window
    {
        Model.DrawingData drawingData = new Model.DrawingData();

        void Draw()
        {
            List<int> xlist = drawingData.GetX();
            List<int> ylist = drawingData.GetY();
            for (int i = 0; i < xlist.Count; i++)
            {
                Ellipse circle = new Ellipse();
                circle.Height = 30;
                circle.Width = 30;
            }
        }


    }
}
