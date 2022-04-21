﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DrawingData
    {
        Logika.IMovingCircles movingCircles = new Logika.MovingCircles();
        int width = 600;
        int height = 200;
        
        public void Restart(int n) {
            movingCircles.StopMoving();
            movingCircles.RemoveCircles();
            movingCircles.CreateCircles(n);
            movingCircles.StartMoving();
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