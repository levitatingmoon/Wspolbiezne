using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public interface ICircles
    {
        void AddCircle(int x, int y, int radius, int vx, int vy);
        void RemoveCircle(int i);
        void RemoveAllCircles();
        int Count();
        int GetX(int i);
        int GetY(int i);
        int GetRadius(int i);
        int GetVx(int i);
        int GetVy(int i);
        void SetVx(int i, int vx);
        void SetVy(int i, int vy);
        void ChangePosition(int i, int x, int y);
    }
}
