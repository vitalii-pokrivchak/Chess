using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct Position
    {


        void CreatePositions()
        {
            int[][] position = new int[8][];
            for (int i = 0; i < 8; i++)
                position[i] = new int[8];
        }
        //List<int> posX; // pos number
        //List<char> posCh; // posChar

        //public void CreatePosts()
        //{
        //    posX = new List<int>();
        //    posCh = new List<char>();

        //    for (int i = 1; i < 9; i++)
        //        posX.Add(i);   // fill desk position by numbers


        //    int chNum; // helper
        //    char ch; // helper to fill listby char


        //    for (int i = 0; i < 8; i++)
        //    {
        //        chNum = 65 + i; // set ascii char
        //        ch = (char)chNum; // set ascii to char
        //        posCh.Add(ch);  // fill desk position by char
        //    }

        //    CheckPositions();

        //}


        //void CheckPositions()
        //{
        //    for (int i = 0; i < 8; i++)
        //        Console.Write(posX[i] + "   ");

        //    Console.WriteLine();


        //    for (int i = 0; i < 8; i++)
        //    {
        //        Console.WriteLine(posCh[i]);
        //        Console.WriteLine();
        //    }
        //}
    }
}
