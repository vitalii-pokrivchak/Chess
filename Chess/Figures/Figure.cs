using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class Figure
    {
        public readonly FigureColor Color;
        public SFigurePosition Position { get; set; }
        public abstract MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid);

        public Figure(FigureColor color)
        {
            Color = color;
        }
    }
}