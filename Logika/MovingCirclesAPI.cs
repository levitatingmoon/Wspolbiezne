using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public abstract class MovingCirclesAPI
    {
        public abstract void CreateCircles(int n);
        public abstract void RemoveCircles();
        public abstract void StartMoving();
        public abstract void StopMoving();
        public abstract int GetX(int i);
        public abstract int GetY(int i);
        public abstract int GetWidth();
        public abstract int GetHeight();
        public abstract int Count();

        public static MovingCirclesAPI CreateMovingCircles()
        {
            return new MovingCircles();
        }
    }
}
