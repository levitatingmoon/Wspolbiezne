using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    internal interface ICircles
    {
        void AddCircle(int x, int y, int radius);
        void RemoveCircle(int i);
        int Count();
        int GetX(int i);
        int GetY(int i);
        int GetRadius(int i);
    }
}
