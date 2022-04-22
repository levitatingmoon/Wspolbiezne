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
        bool moving = false;

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
                circles.AddCircle(rnd.Next(radius, width - radius),
                rnd.Next(radius, height - radius), radius,
                rnd.Next(minVelocity, maxVelocity), 
                rnd.Next(minVelocity, maxVelocity));
            }
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
    }
}
