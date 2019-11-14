using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public sealed class Pawn : Figure
    {
        private bool _firstMove = true;
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {

            int idx = 1;
            if (_color == Color.Black)
            {
                idx = idx * -1;
            }
            Figure fig = deskGrid[newPos.X, newPos.Y];

            if (newPos.Y == Position.Y + idx)
            {
                if (newPos.X == Position.X + 1 || newPos.X == Position.X - 1)
                {
                    if (fig != null)
                    {
                        return MoveState.Fight;
                    }
                }
                if (newPos.X == Position.X)
                {
                    if (fig == null)
                    {
                        return MoveState.Can;
                    }
                }
            }
            if (newPos.Y == Position.Y + idx + idx && newPos.X == Position.X && _firstMove)
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
    }
}
