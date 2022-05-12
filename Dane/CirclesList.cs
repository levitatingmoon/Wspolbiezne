using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class CirclesList : CirclesAPI
    {
        List<Circle> circles = new List<Circle>();

        public override void AddCircle(int x, int y, int radius, int vx, int vy, int mass)
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

        public override int GetX(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetX();
        }

        public override int GetY(int i)
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

        public override void ChangePosition(int i, int x, int y)
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

        public override int GetVx(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].GetVx();
        }

        public override int GetVy(int i)
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

        public override void SetVx(int i, int vx)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetVx(vx);
        }

        public override void SetVy(int i, int vy)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].SetVy(vy);
        }
    }
}
