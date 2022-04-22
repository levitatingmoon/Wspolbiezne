using System;
using System.Threading;
using System.Numerics;

namespace Logika
{
    public class MovingCircles : IMovingCircles
    {
        Dane.ICircles circles;
        int radius = 10;
        int width = 600;
        int height = 200;
        int sleepTime = 200;
        int maxDelta = 5;
        bool moving = false;

        public int Count()
        {
            return circles.Count();
        }

        public void CreateCircles(int n)
        {
            Random rnd = new Random();
            circles = new Dane.CirclesList();
            for (int i = 0; i < n; i++)
            {
                circles.AddCircle(rnd.Next(-width, width), rnd.Next(-height, height), radius);
            }
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetX(int i)
        {
            return circles.GetX(i);
        }

        public int GetY(int i)
        {
            return circles.GetY(i);
        }

        public void RemoveCircles()
        {
            circles.RemoveAllCircles();
        }

        public void StartMoving()
        {
            moving = true;
            for (int i=0; i<circles.Count(); i++)
            {
                Thread t = new Thread(() => MoveCircle(i));
                t.Start();
            }
        }

        public void StopMoving()
        {
            moving = false;
        }

        private void MoveCircle(int i)
        {
            Random rnd = new Random();
            int newPosx = GetX(i);
            int newPosy = GetY(i);
            int x, y, newx, newy;
            while (true)
            {
                if (Math.Abs(newPosx - GetX(i)) < maxDelta && Math.Abs(newPosy - GetY(i)) < maxDelta)
                {
                    newPosx = rnd.Next(0, width);
                    newPosy = rnd.Next(0, height);
                }
                Thread.Sleep(sleepTime);
                x = newPosx - GetX(i);
                y = newPosy - GetY(i);
                float length = (float)Math.Sqrt(x * x + y * y);
                newx = (int)(GetX(i) + x / length * maxDelta);
                newy = (int)(GetY(i) + y / length * maxDelta);
                circles.ChangePosition(i, newx, newy);
                if (!moving) 
                    break;
            }
        }
    }
}
