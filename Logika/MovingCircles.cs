using System;
using System.Threading;
using System.Numerics;
using System.Collections.Generic;

namespace Logika
{
    public class MovingCircles : MovingCirclesAPI
    {
        Dane.CirclesAPI circles;
        List<Thread> threads = new List<Thread>();
        int radius = 20;
        int width = 800;
        int height = 300;
        int sleepTime = 50;
        int minVelocity = 5;
        int maxVelocity = 20;
        int minMass = 1;
        int maxMass = 20;
        bool moving = false;
        readonly object locker = new object();

        public MovingCircles(Dane.CirclesAPI circles = null)
        {
            this.circles = circles ?? Dane.CirclesAPI.CreateCircles();
        }

        public override int Count()
        {
            return circles.Count();
        }

        public override void CreateCircles(int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(radius, width - radius);
                int y = rnd.Next(radius, height - radius);
                for (int j = 0; j < circles.Count(); j++)
                {
                    if (Distance(x, y, circles.GetX(j), circles.GetY(j)) - radius * 2 < 0)
                    {
                        x = rnd.Next(radius, width - radius);
                        y = rnd.Next(radius, height - radius);
                        j = -1;
                    }
                }
                circles.AddCircle(x, y, radius,
                rnd.Next(minVelocity, maxVelocity), 
                rnd.Next(minVelocity, maxVelocity),
                rnd.Next(minMass, maxMass));
            }
        }

        private double Distance(int x1, int y1, int x2, int y2)
        {
            int xDist = x2 - x1;
            int yDist = y2 - y1;
            return Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }

        public override int GetHeight()
        {
            return height;
        }

        public override int GetWidth()
        {
            return width;
        }

        public override int GetX(int i)
        {
            return circles.GetX(i);
        }

        public override int GetY(int i)
        {
            return circles.GetY(i);
        }

        public override void RemoveCircles()
        {
            circles.RemoveAllCircles();
        }

        public override void StartMoving()
        {
            
            moving = true;
            for (int i=0; i<circles.Count(); i++)
            {
                int tmp = i;
                Thread t = new Thread(() => MoveCircle(tmp));
                threads.Add(t);
                t.Start();
            }
        }

        public override void StopMoving()
        {
            moving = false;
            threads.Clear();
        }

        private void MoveCircle(int i)
        {
            while (true)
            {
                for (int j = 0; j < circles.Count(); j++)
                {
                    if (j == i) continue;
                    if ( Distance(circles.GetX(i), circles.GetY(i), circles.GetX(j), circles.GetY(j)) - radius * 2 < 0)
                    {
                        lock(locker)
                        {
                            Collision(i, j);
                        }
                    }
                }
                int newPosx = circles.GetX(i) + circles.GetVx(i);
                int newPosy = circles.GetY(i) + circles.GetVy(i);
                if ( newPosx < radius || newPosx > width - radius)
                {
                    circles.SetVx(i, -circles.GetVx(i));
                }
                if (newPosy < radius || newPosy > height - radius)
                {
                    circles.SetVy(i, -circles.GetVy(i));
                }
                circles.ChangePosition(i, circles.GetX(i) + circles.GetVx(i), circles.GetY(i) + circles.GetVy(i));
                Thread.Sleep(sleepTime);
                if (!moving)
                    break;
            }
        }

        private void Rotate(ref int vx, ref int vy, double angle)
        {
            int newx = (int)(vx * Math.Cos(angle) - vy * Math.Sin(angle));
            int newy = (int)(vx * Math.Sin(angle) + vy * Math.Cos(angle));
            vx = newx;
            vy = newy;
        }

        private void Collision(int circle1, int circle2)
        {
            int vxDiff = circles.GetVx(circle1) - circles.GetVx(circle2);
            int vyDiff = circles.GetVy(circle1) - circles.GetVy(circle2);
            int xDist = circles.GetX(circle2) - circles.GetX(circle1);
            int yDist = circles.GetY(circle2) - circles.GetY(circle1);
            if (vxDiff * xDist + vyDiff * yDist >= 0)
            {
                double angle = -Math.Atan2(yDist, xDist);
                int m1 = circles.GetMass(circle1);
                int m2 = circles.GetMass(circle2);

                int u1x = circles.GetVx(circle1);
                int u1y = circles.GetVy(circle1);
                Rotate(ref u1x, ref u1y, angle);
                int u2x = circles.GetVx(circle2);
                int u2y = circles.GetVy(circle2);
                Rotate(ref u2x, ref u2y, angle);

                int v1x = u1x * (m1 - m2) / (m1 + m2) + u2x * 2 * m2 / (m1 + m2);
                int v1y = u1y;
                int v2x = u2x * (m1 - m2) / (m1 + m2) + u1x * 2 * m2 / (m1 + m2);
                int v2y = u2y;

                Rotate(ref v1x, ref v1y, -angle);
                Rotate(ref v2x, ref v2y, -angle);

                circles.SetVx(circle1, v1x);
                circles.SetVy(circle1, v1y);
                circles.SetVx(circle2, v2x);
                circles.SetVy(circle2, v2y);
            }
        }
    }
}
