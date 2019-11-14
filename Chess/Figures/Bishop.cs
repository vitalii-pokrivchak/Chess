using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Bishop : Figure
    {
        public Bishop(FigureColor Color) : base(Color)
        {

        }
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(Position))
            {
                return MoveState.Cannot;
            }
            return MoveState.Cannot;
        }
    }
}
