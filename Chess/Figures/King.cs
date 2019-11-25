using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class King : Figure
    {
        public King(FigureColor Color) : base(Color)
        {

        }
        public override MoveState CheckMove(SFigurePosition newPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(Position))
            {
                return MoveState.Cannot;
            }

            if (newPos.X == Position.X + 1 && newPos.Y == Position.Y ||
                newPos.X == Position.X + 1 && newPos.Y == Position.Y + 1 ||
                newPos.X == Position.X + 1 && newPos.Y == Position.Y - 1 ||
                newPos.X == Position.X - 1 && newPos.Y == Position.Y ||
                newPos.X == Position.X - 1 && newPos.Y == Position.Y + 1 ||
                newPos.X == Position.X - 1 && newPos.Y == Position.Y - 1 ||
                newPos.X == Position.X && newPos.Y == Position.Y + 1 ||
                newPos.X == Position.X && newPos.Y == Position.Y - 1)
            {
                Figure tempFig = deskGrid[newPos.X, newPos.Y];
                
                deskGrid[newPos.X, newPos.Y] = this;

                foreach (var Fig in deskGrid)
                {
                    if (Fig.Color != this.Color &&
                        Fig.CheckMove(newPos, ref deskGrid) == MoveState.Fight)
                    {
                        deskGrid[newPos.X, newPos.Y] = tempFig;
                        return MoveState.Cannot;
                    }                    
                }

                deskGrid[newPos.X, newPos.Y] = tempFig;
                if (tempFig == null)
                {
                    return MoveState.Can;
                }
                return MoveState.Fight;
            }

            return MoveState.Cannot;
        }
    }
}
