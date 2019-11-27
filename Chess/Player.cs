using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Player
    {
        FigureColor _color;
        public FigureColor Color { get { return _color; } }
        public List<string> _moves;
        public List<Figure> _deadFigures;

        Player(FigureColor color)
        {
            _color = color;
            
        }
    }
}