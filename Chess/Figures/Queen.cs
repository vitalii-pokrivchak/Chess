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
        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            Figure fig = deskGrid[newPos.X, newPos.Y];

            int idx = 1;
            int idy = 1;

            if (newPos.X > currPos.X && newPos.Y < currPos.Y)
            {
                idy *= -1;
            }

            if (newPos.X < currPos.X && newPos.Y > currPos.Y)
            {
                idx *= -1;
            }

            if (newPos.X < currPos.X && newPos.Y < currPos.Y)
            {
                idx *= -1;
                idy *= -1;
            }

            int x = currPos.X + idx;
            int y = currPos.Y + idy;

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

            if (newPos.X == currPos.X && newPos.Y != currPos.Y)
            {
                idx = 1;
                if (newPos.Y > currPos.Y)
                {
                    idx *= -1;
                }

                for (int i = currPos.Y + idx; i != newPos.Y - idx; i += idx)
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

            if (newPos.X != currPos.X && newPos.Y == currPos.Y)
            {
                idx = 1;
                if (newPos.X > currPos.X)
                {
                    idx *= -1;
                }

                for (int i = currPos.X + idx; i != newPos.X - idx; i += idx)
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

        public override byte[] GetImage()
        {
            throw new NotImplementedException();
        }
    }
}
