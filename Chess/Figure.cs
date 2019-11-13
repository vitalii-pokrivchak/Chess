using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Figure
    {
        public string Name { get; set; }
        public Color GetColor { get; set; }
        public virtual bool CheckMove() => true;
    }
}
