using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
     public abstract class Figure
    {        
        public SFigurePosition Position { get; set; }
        public abstract void Move(SFigurePosition pos);
    }
}
