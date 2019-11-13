using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{

    public class Figura
    {
        public string Name { get; set; }
        // Перевірка чи може фігура робити такий хід
        public bool CheckMove(int x, int y, Figura _figuras) {
            return false;
        } 
        public Color GetColor { get; set; }


    }
}
