using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public interface IMovingCircles
    {
        void CreateCircles(int n);
        void RemoveCircles();
        void StartMoving();
        void StopMoving();
        int GetX(int i);
        int GetY(int i);
    }
}
