using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public abstract class CirclesAPI
    {
        public abstract void AddCircle(double x, double y, int radius, double vx, double vy, int mass);
        public abstract void RemoveCircle(int i);
        public abstract void RemoveAllCircles();
        public abstract int Count();
        public abstract double GetX(int i);
        public abstract double GetY(int i);
        public abstract int GetRadius(int i);
        public abstract double GetVx(int i);
        public abstract double GetVy(int i);
        public abstract int GetMass(int i);
        public abstract void SetVx(int i, double vx);
        public abstract void SetVy(int i, double vy);
        public abstract void ChangePosition(int i, double x, double y);

        public static CirclesAPI CreateCircles()
        {
            return new CirclesList();
        }
    }
}
