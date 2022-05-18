using System;
using System.Threading;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logika
{
    public class MovingCircles : MovingCirclesAPI
    {
        Dane.CirclesAPI circles;
        List<Thread> threads = new List<Thread>();
        int radius = 20;
        int width = 800;
        int height = 300;
        int sleepTime = 10;
        int minVelocity = 1;
        int maxVelocity = 3;
        int minMass = 1;
        int maxMass = 5;
        bool moving = false;
        readonly object locker = new object();
        List <bool> collidedCircles = new List<bool> ();
        List <double> oldPosx = new List<double> ();
        List <double> oldPosy = new List<double> ();

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
            collidedCircles.Clear();
            oldPosx.Clear();
            oldPosy.Clear();
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
                rnd.Next(minVelocity, maxVelocity), rnd.Next(minMass, maxMass));
                collidedCircles.Add(false);
                oldPosx.Add(x);
                oldPosy.Add(y);
            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double xDist = x2 - x1;
            double yDist = y2 - y1;
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
            return (int)circles.GetX(i);
        }

        public override int GetY(int i)
        {
            return (int)circles.GetY(i);
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
            //double oldPosx = circles.GetX(i);
            //double oldPosy = circles.GetY(i);

            while (true)
            {
                if (collidedCircles[i]==false)
                {
                    //odbicie od ściany
                    double newPosx = circles.GetX(i) + circles.GetVx(i);
                    double newPosy = circles.GetY(i) + circles.GetVy(i);
                    if ((newPosx < radius || newPosx > width - radius))
                    {
                        circles.SetVx(i, -circles.GetVx(i));
                    }
                    if (newPosy < radius || newPosy > height - radius)
                    {
                        circles.SetVy(i, -circles.GetVy(i));
                    }

                    //kolizje
                    CheckCollisions(i);

                    oldPosx[i] = circles.GetX(i);
                    oldPosy[i] = circles.GetY(i);
                    //zmiana pozycji
                    if (collidedCircles[i] == false)
                        circles.ChangePosition(i, circles.GetX(i) + circles.GetVx(i), circles.GetY(i) + circles.GetVy(i));
                }
                
                Thread.Sleep(sleepTime);
                if (!moving)
                    break;
            }
        }

        private void CheckCollisions(int i)
        {
            lock (locker)
            {
                for (int j = 0; j < circles.Count(); j++)
                {
                    if (j == i) continue;

                    if (Distance(circles.GetX(i), circles.GetY(i), circles.GetX(j), circles.GetY(j)) - radius * 2 < 0)
                    {
                        collidedCircles[j] = true;
                        circles.ChangePosition(i, oldPosx[i], oldPosy[i]);
                        circles.ChangePosition(j, oldPosx[j], oldPosy[j]);
                        Collision(i, j);
                        collidedCircles[j] = false;
                    }
                }
            }
        }

        private void Rotate(ref double vx, ref double vy, double angle)
        {
            double newx = (vx * Math.Cos(angle) - vy * Math.Sin(angle));
            double newy = (vx * Math.Sin(angle) + vy * Math.Cos(angle));
            vx = newx;
            vy = newy;
        }

        private void Collision(int circle1, int circle2)
        {
            /*
            double vxDiff = circles.GetVx(circle1) - circles.GetVx(circle2);
            double vyDiff = circles.GetVy(circle1) - circles.GetVy(circle2);
            double xDist = circles.GetX(circle2) - circles.GetX(circle1);
            double yDist = circles.GetY(circle2) - circles.GetY(circle1);

            double x1 = circles.GetX(circle1);
            double x2 = circles.GetX(circle2);
            double y1 = circles.GetY(circle1);
            double y2 = circles.GetY(circle2);
            double d;


            if (vxDiff * xDist + vyDiff * yDist >= 0)
            {
                double angle = -Math.Atan2(yDist, xDist);
                int m1 = circles.GetMass(circle1);
                int m2 = circles.GetMass(circle2);

                double u1x = circles.GetVx(circle1);
                double u1y = circles.GetVy(circle1);
                Rotate(ref u1x, ref u1y, angle);
                double u2x = circles.GetVx(circle2);
                double u2y = circles.GetVy(circle2);
                Rotate(ref u2x, ref u2y, angle);

                double v1x = u1x * (m1 - m2) / (m1 + m2) + u2x * 2 * m2 / (m1 + m2);
                double v1y = u1y;
                double v2x = u2x * (m2 - m1) / (m1 + m2) + u1x * 2 * m1 / (m1 + m2);
                double v2y = u2y;

                Rotate(ref v1x, ref v1y, -angle);
                Rotate(ref v2x, ref v2y, -angle);

                circles.SetVx(circle1, v1x);
                circles.SetVy(circle1, v1y);
                circles.SetVx(circle2, v2x);
                circles.SetVy(circle2, v2y);
            }*/
            
            Debug.WriteLine("Hit");
            

            double x1 = circles.GetX(circle1);
            double x2 = circles.GetX(circle2);
            double y1 = circles.GetY(circle1);
            double y2 = circles.GetY(circle2);
            double vx1 = circles.GetVx(circle1);
            double vx2 = circles.GetVx(circle2);
            double vy1 = circles.GetVy(circle1);
            double vy2 = circles.GetVy(circle2);
            int m1 = circles.GetMass(circle1);
            int m2 = circles.GetMass(circle2);
            double d = Distance(x1, y1, x2, y2);

            Debug.WriteLine(vx1+" "+vy1);
            Debug.WriteLine(vx2 + " " + vy2);
            /*
            if (DoCirclesOverlap(x1, y1, x2, y2, radius, radius))
            {
                
                double overlap = 0.5 * (d - 2 * radius);
                circles.ChangePosition(circle1, (int)(x1 - overlap * (x1 - x2) / d), (int)(y1 - overlap * (y1 - y2) / d));
                circles.ChangePosition(circle2, (int)(x2 + overlap * (x1 - x2) / d), (int)(y2 + overlap * (y1 - y2) / d));
            }*/
            
            x1 = circles.GetX(circle1);
            x2 = circles.GetX(circle2);
            y1 = circles.GetY(circle1);
            y2 = circles.GetY(circle2);
            d = Distance(x1, y1, x2, y2);
            /*
            double nx = (x2 - x1) / d;
            double ny = (y2 - y1) / d;
            double p = 2 * (vx1 * nx + vy1 * ny - vx2 * nx - vy2 * ny) / (circles.GetMass(circle1) + circles.GetMass(circle2));
            circles.SetVx(circle1, (int)(vx1 - p * m1 * nx));
            circles.SetVy(circle1, (int)(vy1 - p * m1 * ny));
            circles.SetVx(circle2, (int)(vx2 + p * m2 * nx));
            circles.SetVy(circle2, (int)(vy2 + p * m2 * ny));
            */
            
            d = Distance(x1, y1, x2, y2);
            double vxDiff = circles.GetVx(circle1) - circles.GetVx(circle2);
            double vyDiff = circles.GetVy(circle1) - circles.GetVy(circle2);
            double xDist = circles.GetX(circle2) - circles.GetX(circle1);
            double yDist = circles.GetY(circle2) - circles.GetY(circle1);
            if (vxDiff * xDist + vyDiff * yDist >= 0)
            {
                 /*
                 //znajdź minimalny dystans do przesunięcia - minimal translation distance
                 double mtdx = (x1 - x2) * ((2 * radius - d) / d);
                 double mtdy = (y1 - y2) * ((2 * radius - d) / d);
                 //przesunięcie
                 circles.ChangePosition(circle1, (int)(x1 + (mtdx / 2)), (int)(y1 + (mtdy / 2)));
                 circles.ChangePosition(circle2, (int)(x2 - (mtdx / 2)), (int)(y2 - (mtdy / 2)));
                */
                
                if (DoCirclesOverlap(x1, y1, x2, y2, radius, radius))
                {
                    d = Distance(x1, y1, x2, y2);
                    double overlap = 0.5 * (d - 2 * radius);
                    circles.ChangePosition(circle1, x1 - (overlap * (x1 - x2) / d), y1 - (overlap * (y1 - y2) / d));
                    circles.ChangePosition(circle2, x2 + (overlap * (x1 - x2) / d), y2 + (overlap * (y1 - y2) / d));
                }
            
                //wektor normalny
                double nx = (x2 - x1) / d;
                double ny = (y2 - y1) / d;

                //wektor styczny
                double tx = -ny;
                double ty = nx;
                //iloczyny skalarne
                double v1n = nx * vx1 + ny * vy1;
                double v1t = tx * vx1 + ty * vy1;
                double v2n = nx * vx2 + ny * vy2;
                double v2t = tx * vx2 + ty * vy2;
                //nowe prędkości normalne
                double v1nTag = (v1n * (m1 - m2) + 2 * m2 * v2n) / (m1 + m2);
                double v2nTag = (v2n * (m2 - m1) + 2 * m1 * v1n) / (m1 + m2);
                //konwersja skalarów i wektorów stycznych na wektory
                double v1nTagx = v1nTag * nx;
                double v1nTagy = v1nTag * ny;
                double v1tTagx = v1t * tx;
                double v1tTagy = v1t * ty;
                double v2nTagx = v2nTag * nx;
                double v2nTagy = v2nTag * ny;
                double v2tTagx = v2t * tx;
                double v2tTagy = v2t * ty;
                //odśwież prędkości
                //circles.ChangePosition(circle2, x2, y2);
                circles.SetVx(circle1, (v1nTagx + v1tTagx));
                circles.SetVy(circle1, (v1nTagy + v1tTagy));
                circles.SetVx(circle2, (v2nTagx + v2tTagx));
                circles.SetVy(circle2, (v2nTagy + v2tTagy));
                Debug.WriteLine(circles.GetVx(circle1) + " " + circles.GetVy(circle1));
                Debug.WriteLine(circles.GetVx(circle2) + " " + circles.GetVy(circle2));
            }

        }



         private bool DoCirclesOverlap(double x1, double y1, double x2, double y2, double r1, double r2)
         {
             return Math.Abs((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) <= (r1 + r2) * (r1 + r2);
         }
    }
}
