using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class CirclesList : ICircles
    {
        List<Circle> circles;

        public void AddCircle(int x, int y, int radius)
        {
            circles.Add(new Circle(x, y, radius));
        }

        public void RemoveCircle(int i)
        {
            circles.RemoveAt(i);
        }

        public int Count()
        {
            return circles.Count;
        }

        public int GetX(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetX();
        }

        public int GetY(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetY();
        }

        public int GetRadius(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetRadius();
        }

        public void ChangePosition(int i, int x, int y)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetX(x);
            circles[i].SetY(y);
        }

        public void RemoveAllCircles()
        {
            circles.Clear();
        }
    }
}
