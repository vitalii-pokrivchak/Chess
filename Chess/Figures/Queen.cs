using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Queen : Figure
    {
        public Queen(FigureColor Color) : base(Color)
        {

        }
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(Position))
            {
                return MoveState.Cannot;
            }

            Figure fig = deskGrid[newPos.X, newPos.Y];

            int idx = 1;
            int idy = 1;

            if (newPos.X > Position.X && newPos.Y < Position.Y)
            {
                idy *= -1;
            }

            if (newPos.X < Position.X && newPos.Y > Position.Y)
            {
                idx *= -1;
            }

            if (newPos.X < Position.X && newPos.Y < Position.Y)
            {
                idx *= -1;
                idy *= -1;
            }

            int x = Position.X + idx;
            int y = Position.Y + idy;

            for (; x < newPos.X && y < newPos.Y; x += idx, y += idy)
            {
                if (deskGrid[x, y] != null)
                {
                    return MoveState.Cannot;
                }
            }

            if (x == newPos.X && y == newPos.Y)
            {
                if (deskGrid[x, y] != null)
                {
                    return MoveState.Fight;
                }
                return MoveState.Can;
            }

            if (newPos.X == Position.X && newPos.Y != Position.Y)
            {
                idx = 1;
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
                idx = 1;
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
