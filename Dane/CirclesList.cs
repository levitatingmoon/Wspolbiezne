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
        Logger logger;

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
            return circles[i].x;
        }

        public override double GetY(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].y;
        }

        public override int GetRadius(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].radius;
        }

        public override void ChangePosition(int i, double x, double y)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].x = x;
            circles[i].y = y;
        }

        public override void RemoveAllCircles()
        {
            circles.Clear();
        }

        public override double GetVx(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].vx;
        }

        public override double GetVy(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].vy;
        }

        public override int GetMass(int i)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            return circles[i].mass;
        }

        public override void SetVx(int i, double vx)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].vx = vx;
        }

        public override void SetVy(int i, double vy)
        {
            if (i < 0) i = 0;
            if (i >= circles.Count) i = circles.Count - 1;
            circles[i].vy = vy;
        }

        public override int GetWidth()
        {
            return width;
        }

        public override int GetHeight()
        {
            return height;
        }

        public override void StartLogger()
        {
            this.logger = new Logger(circles);
        }

        public override void StopLogger()
        {
            logger.stop();
        }
    }
}
