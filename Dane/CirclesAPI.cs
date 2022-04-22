using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public abstract class CirclesAPI
    {
        public abstract void AddCircle(int x, int y, int radius, int vx, int vy);
        public abstract void RemoveCircle(int i);
        public abstract void RemoveAllCircles();
        public abstract int Count();
        public abstract int GetX(int i);
        public abstract int GetY(int i);
        public abstract int GetRadius(int i);
        public abstract int GetVx(int i);
        public abstract int GetVy(int i);
        public abstract void SetVx(int i, int vx);
        public abstract void SetVy(int i, int vy);
        public abstract void ChangePosition(int i, int x, int y);

        public static CirclesAPI CreateCircles()
        {
            return new CirclesList();
        }
    }
}
