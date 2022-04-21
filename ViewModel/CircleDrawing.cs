using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class CircleDrawing
    {
        int x, y, diameter;

        public CircleDrawing(int x, int y, int radius)
        {
            this.x = x - radius;
            this.y = y - radius;
            diameter = radius * 2;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
}
