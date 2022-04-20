using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public interface ICircles
    {
        void AddCircle(int x, int y, int radius);
        void RemoveCircle(int i);
        void RemoveAllCircles();
        int Count();
        int GetX(int i);
        int GetY(int i);
        int GetRadius(int i);
        void ChangePosition(int i, int x, int y);
    }
}
