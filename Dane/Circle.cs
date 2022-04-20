using System;

namespace Dane
{
    internal class Circle
    {
        private int x;
        private int y;
        private int radius;

        public Circle(int x, int y, int radius)
        {
            this.x = x; this.y = y; this.radius = radius;
        }

        public Circle() : this(0,0,10) { }

        public int GetX() { return x; }
        public int GetY() { return y; }
        public int GetRadius() { return radius; }

        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
    }
}
