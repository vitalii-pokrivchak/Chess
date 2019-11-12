using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Figura
    {
        public string Name { get; set; }
        public struct Positon
        {
            public enum A: byte {a, b, c, d, e, f, g, h}
            public enum B : byte {1, 2, 3, 4, 5, 6, 7, 8}
        }
    }
}
