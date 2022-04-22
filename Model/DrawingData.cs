using Logika;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DrawingData
    {
        Logika.MovingCirclesAPI movingCircles = new Logika.MovingCircles();
        int width = 800;
        int height = 300;

        public DrawingData(Logika.MovingCirclesAPI movingCircles = null)
        {
            this.movingCircles = movingCircles ?? Logika.MovingCirclesAPI.CreateMovingCircles();   
        }

        public void Start(int n) {
            movingCircles.CreateCircles(n);
            movingCircles.StartMoving();
        }

        public void Stop()
        {
            movingCircles.StopMoving();
            movingCircles.RemoveCircles();
        }

        public List<int> GetX()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < movingCircles.Count(); i++)
            {
                list.Add(movingCircles.GetX(i) * width / movingCircles.GetWidth());
            }
            return list;
        }

        public List<int> GetY()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < movingCircles.Count(); i++)
            {
                list.Add(movingCircles.GetY(i) * height / movingCircles.GetHeight());
            }
            return list;
        }

    }
}
