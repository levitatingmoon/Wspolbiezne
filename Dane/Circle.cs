﻿using System;

namespace Dane
{
    internal class Circle
    {
        private int x;
        private int y;
        private int radius;
        private int vx;
        private int vy;
        private int mass;

        public Circle(int x, int y, int radius, int vx, int vy, int mass)
        {
            this.x = x; this.y = y;
            this.radius = radius;
            this.vx = vx; this.vy = vy;
            this.mass = mass;
        }

        public Circle() : this(0,0,10, 5, 5, 10) { }

        public int GetX() { return x; }
        public int GetY() { return y; }
        public int GetRadius() { return radius; }
        public int GetVx() { return vx; }
        public int GetVy() { return vy; }
        public int GetMass() { return mass; }

        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public void SetVx(int vx) { this.vx = vx; }
        public void SetVy(int vy) { this.vy = vy; }
    }
}
