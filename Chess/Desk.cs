using Chess.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Desk
    {
        const int DESKSIZE = 8;
        Figure[,] _deskGrid = new Figure[DESKSIZE, DESKSIZE];
        public void ClearDesk()
        {
            for (int i = 0;i<DESKSIZE;i++)
            {
                _deskGrid[1, i] = new Pawn(FigureColor.White);
                _deskGrid[6, i] = new Pawn(FigureColor.Black);
            }
            _deskGrid[0, 0] = new Rook(FigureColor.White);
            _deskGrid[0, 7] = new Rook(FigureColor.White);
            _deskGrid[7, 0] = new Rook(FigureColor.Black);
            _deskGrid[7, 7] = new Rook(FigureColor.Black);

            _deskGrid[0, 1] = new Horse(FigureColor.White);
            _deskGrid[0, 6] = new Horse(FigureColor.White);
            _deskGrid[7, 1] = new Horse(FigureColor.Black);
            _deskGrid[7, 6] = new Horse(FigureColor.Black);

            _deskGrid[0, 2] = new Bishop(FigureColor.White);
            _deskGrid[0, 5] = new Bishop(FigureColor.White);
            _deskGrid[7, 2] = new Bishop(FigureColor.Black);
            _deskGrid[7, 5] = new Bishop(FigureColor.Black);

            _deskGrid[0, 4] = new Queen(FigureColor.White);
            _deskGrid[0, 3] = new King(FigureColor.White);
            _deskGrid[7, 4] = new Queen(FigureColor.Black);
            _deskGrid[7, 3] = new King(FigureColor.Black);

        }
        public Figure this[int i, int j]
        {
            get => _deskGrid[i, j];
        }
    }

}
