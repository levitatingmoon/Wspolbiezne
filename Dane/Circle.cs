using System;

namespace Dane
{
    internal class Circle
    {
        public double x { get; set; }
        public double y { get; set; }
        public int radius { get; set; }
        public double vx { get; set; }
        public double vy { get; set; }
        public int mass { get; set; }

        public Circle(double x, double y, int radius, double vx, double vy, int mass)
        {
            this.x = x; this.y = y;
            this.radius = radius;
            this.vx = vx; this.vy = vy;
            this.mass = mass;
        }

        public Circle() : this(0,0,10, 5, 5, 10) { }
/*
        public double GetX() { return x; }
        public double GetY() { return y; }
        public int GetRadius() { return radius; }
        public double GetVx() { return vx; }
        public double GetVy() { return vy; }
        public int GetMass() { return mass; }

        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }
        public void SetVx(double vx) { this.vx = vx; }
        public void SetVy(double vy) { this.vy = vy; }*/
    }
}
