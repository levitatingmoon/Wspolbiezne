using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class CirclesList : CirclesAPI
    {
        List<Circle> circles = new List<Circle>();
        int width = 800;
        int height = 300;

        public override void AddCircle(double x, double y, int radius, double vx, double vy, int mass)
        {
            circles.Add(new Circle(x, y, radius, vx, vy, mass));
        }

        public override void RemoveCircle(int i)
        {
            circles.RemoveAt(i);
        }

        public override int Count()
        {
            return circles.Count;
        }

        public override double GetX(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetX();
        }

        public override double GetY(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetY();
        }

        public override int GetRadius(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetRadius();
        }

        public override void ChangePosition(int i, double x, double y)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetX(x);
            circles[i].SetY(y);
        }

        public override void RemoveAllCircles()
        {
            circles.Clear();
        }

        public override double GetVx(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetVx();
        }

        public override double GetVy(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetVy();
        }

        public override int GetMass(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetMass();
        }

        public override void SetVx(int i, double vx)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetVx(vx);
        }

        public override void SetVy(int i, double vy)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetVy(vy);
        }

        public override int GetWidth()
        {
            return width;
        }

        public override int GetHeight()
        {
            return height;
        }
    }
}
