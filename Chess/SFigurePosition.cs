using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct SFigurePosition
    {
        private int _x;
        private int _y;

        public void SetPosition(int x, int y)
        {
            if (x < 1 || x > 8 || y < 'a' || y > 'h')
            {
                throw new Exception();
            }

            _x = x;
            _y = y;
        }

        public Tuple<int, int> GetPosition()
        {
            return new Tuple<int, int>(_x, _y);
        }
    }
}
