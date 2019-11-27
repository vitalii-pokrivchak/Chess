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
            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            if (Color == FigureColor.White)
                return ResourceImages.BishopWhite;
            else
                return ResourceImages.BishopBlack;
        }
    }
}
