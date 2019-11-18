using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Rook : Figure
    {
        public Rook(FigureColor Color) : base(Color)
        {

        }
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(Position))
            {
                return MoveState.Cannot;
            }

            Figure fig = deskGrid[newPos.X, newPos.Y];

            if (newPos.X == Position.X && newPos.Y != Position.Y)
            {
                int idx = 1;
                if (newPos.Y > Position.Y)
                {
                    idx *= -1;
                }

                for (int i = Position.Y + idx; i != newPos.Y - idx; i += idx)
                {
                    if (deskGrid[newPos.X, newPos.Y] != null)
                    {
                        return MoveState.Cannot;
                    }
                }

                if (fig != null)
                {
                    return MoveState.Fight;
                }

                return MoveState.Can;

            }

            if (newPos.X != Position.X && newPos.Y == Position.Y)
            {
                int idx = 1;
                if (newPos.X > Position.X)
                {
                    idx *= -1;
                }

                for (int i = Position.X + idx; i != newPos.X - idx; i += idx)
                {
                    if (deskGrid[newPos.X, newPos.X] != null)
                    {
                        return MoveState.Cannot;
                    }
                }

                if (fig != null)
                {
                    return MoveState.Fight;
                }

                return MoveState.Can;
            }
            return MoveState.Cannot;
        }
    }
}
