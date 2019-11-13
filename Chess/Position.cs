using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct Position
    {
        static public int GetPosition(string _position)
        {
            if (_position.Length == 2){
                _position = _position.ToLower();
                var x = (int)(_position[0] - 97);
                var y = (int)(_position[1] - 49);
                System.Console.WriteLine($"You input: {_position}\n");
                System.Console.WriteLine($"First: {x}\nSeckond: {y}");
                int a = 0;
            return x;
            }
            else
                {
               System.Console.WriteLine($"Plase chouse you move using two leters");
                return 0;
            }
        }
    }
}


