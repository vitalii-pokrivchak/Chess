using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Pawn : Figure
    {
        public Pawn(FigureColor Color) : base(Color)
        {

        }
        private bool _firstMove = true;
        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            int idx = 1;
            if (Color == FigureColor.Black)
            {
                idx = idx * -1;
            }
            Figure fig = deskGrid[newPos.X, newPos.Y];

            if (newPos.Y == currPos.Y + idx)
            {
                if (newPos.X == currPos.X + 1 || newPos.X == currPos.X - 1)
                {
                    if (fig != null)
                    {
                        return MoveState.Fight;
                    }
                }
                if (newPos.X == currPos.X)
                {
                    if (fig == null)
                    {
                        return MoveState.Can;
                    }
                }
            }
            if (newPos.Y == currPos.Y + idx + idx && newPos.X == currPos.X && _firstMove)
            {
                _firstMove = false;
                
                Figure fig1 = deskGrid[newPos.X, newPos.Y - idx];
                if (fig == null && fig1 == null)
                {
                    return MoveState.Can;
                }
            }
            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            throw new NotImplementedException();
        }
    }
}
