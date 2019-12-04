using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class Figure
    {
        public readonly FigureColor Color;
        public abstract MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid);
        public abstract byte[] GetImage();
        public abstract int FigureOrder { get; }
        public Figure(FigureColor color)
        {
            Color = color;
        }
    }
}