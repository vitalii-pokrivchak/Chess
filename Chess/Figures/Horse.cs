using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Horse : Figure
    {
        public Horse(FigureColor Color) : base(Color)
        {

        }
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(Position))
            {
                return MoveState.Cannot;
            }

            if (newPos.X == Position.X + 1 && newPos.Y == Position.Y + 3 ||
                newPos.X == Position.X + 1 && newPos.Y == Position.Y - 3 ||
                newPos.X == Position.X - 1 && newPos.Y == Position.Y + 3 ||
                newPos.X == Position.X - 1 && newPos.Y == Position.Y - 3 ||
                newPos.X == Position.X + 3 && newPos.Y == Position.Y + 1 ||
                newPos.X == Position.X + 3 && newPos.Y == Position.Y - 1 ||
                newPos.X == Position.X - 3 && newPos.Y == Position.Y + 1 ||
                newPos.X == Position.X - 3 && newPos.Y == Position.Y - 1)
            {
                Figure fig = deskGrid[newPos.X, newPos.Y];

                if (fig == null)
                {
                    return MoveState.Can;
                }

                if (fig.Color != this.Color)
                {
                    return MoveState.Fight;
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
