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
        SFigurePosition _activeFigure;
        public void ClearDesk()
        {
            for (int i = 0; i < DESKSIZE; i++)
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

            _deskGrid[0, 3] = new Queen(FigureColor.White);
            _deskGrid[0, 4] = new King(FigureColor.White);
            _deskGrid[7, 3] = new Queen(FigureColor.Black);
            _deskGrid[7, 4] = new King(FigureColor.Black);
        }
        public Figure this[int i, int j]
        {
            get => _deskGrid[i, j];
        }
        public bool ActivateFigure(int i, int j, Player player)
        {
            if (player.Color == _deskGrid[i, j].Color)
            {
                _activeFigure.SetPosition(-1, -1);
                return false;
            }
            _activeFigure.SetPosition(i, j);
            return true;
        }

        public void AvailableMoves(int i, int j)
        {
            for (int idx = 0; idx < DESKSIZE; idx++)
            {
                for (int idy = 0; idy < DESKSIZE; idy++)
                {
                    if (_deskGrid[i, j].CheckMove(new SFigurePosition(idx, idy),
                        new SFigurePosition(i, j),
                        ref _deskGrid) == MoveState.Can ||
                        _deskGrid[i, j].CheckMove(new SFigurePosition(idx, idy),
                        new SFigurePosition(i, j),
                        ref _deskGrid) == MoveState.Fight)
                    {
                        // call event to paint current cell
                    }
                }
            }
        }

        public void Move(int i, int j, Player player)
        {
            if (_activeFigure.X != -1 || _activeFigure.Y != -1)
            {
                if (_deskGrid[i, j].CheckMove(new SFigurePosition(i, j), new SFigurePosition(_activeFigure.X, _activeFigure.Y), ref _deskGrid) != MoveState.Cannot)
                {
                    if(_deskGrid[i,j] != null)
                    {
                        player._deadFigures.Add(_deskGrid[i, j]);
                    }
                    _deskGrid[i, j] = _deskGrid[_activeFigure.X, _activeFigure.Y];
                }
            }
        }
    }

}
