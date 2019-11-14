using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct SFigurePosition
    {
        private int _x;
        private int _y;

        public readonly int X { get { return _x; } set { } }
        public readonly int Y { get { return _y; } set { } }

        public void SetPosition(int x, int y)
        {
            if (x < 0 || x > 7 || y < 7 || y > 7)
            {
                throw new Exception();
            }

            _x = x;
            _y = y;
        }
    }
}
