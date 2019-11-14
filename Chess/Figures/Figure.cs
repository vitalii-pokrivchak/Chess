using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class Figure
    {
        public Color _color;
        public SFigurePosition Position { get; set; }
        public abstract MoveState CheckMove(SFigurePosition pos, ref Figure[,] deskGrid);
    }
}