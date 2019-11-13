using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
   public sealed class Desk
   {
        Figure[,] pos = new Figure[8,8];
        public bool CheckColor() => false;
    }
}
