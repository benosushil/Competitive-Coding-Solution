using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = IsSuduko(4, new int[,]
            {
                { 1,2,3,4} ,
                { 3,4,1,2},
                { 2,3,4,1},
                { 4,1,2,3}
            });
            Console.WriteLine("Is Given 2 x 2  sudoku valid ="  + result);


            result = IsSuduko(9, new int[,]
            {
                { 1,2,3,4, 5,6,7,8,9 } ,
                { 4, 5,6,7,8,9,1,2,3},
                { 7,8,9,1,2,3,4, 5,6},
                { 2,3,4, 5,6,7,8,9,1},
                { 5,6,7,8,9,1,2,3,4, },
                { 8,9,1,2,3,4, 5,6,7},
                { 3,4, 5,6,7,8,9,1,2},
                { 6,7,8,9,1,2,3,4, 5},
                { 9, 1,2,3,4, 5,6,7,8,}
            });
            Console.WriteLine("Is Given 3 x 3  sudoku valid =" + result);

            Console.ReadLine();
        }

        public static bool IsSuduko(int sudukoLength, int[,] suduko)
        {
            if (sudukoLength < 4)
                return false;
            var sqrt = (int)Math.Sqrt(sudukoLength);
            if (Math.Sqrt(sudukoLength) % 1 != 0)
                return false;
            if (suduko?.Length != sudukoLength * sudukoLength)
                return false;

            if (suduko.GetLength(0) != sudukoLength)
                return false;

            var columnsCheck = new bool[sudukoLength, sudukoLength];
            var rowsCheck = new bool[sudukoLength, sudukoLength];
            var boxesCheck = new bool[sudukoLength, sudukoLength];

            for (int i = 0; i < sudukoLength; i++)
            {
                for (int j = 0; j < sudukoLength; j++)
                {
                    var currentElement = suduko[i, j];
                    var currentElementIndex = currentElement - 1;

                    var box = ((i / sqrt) * sqrt) // rows starts at 0, 3, 6 for length 9 sudoku
                        + (j / sqrt); // column 0, 1, 2
                    if (currentElementIndex >= 0 && currentElementIndex < sudukoLength)
                    {
                        if (columnsCheck[j, currentElementIndex] == false &&
                            rowsCheck[i, currentElementIndex] == false &&
                            boxesCheck[box, currentElementIndex] == false)
                        {
                            columnsCheck[j, currentElementIndex] = true;
                            rowsCheck[i, currentElementIndex] = true;
                            boxesCheck[box, currentElementIndex] = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        } 
    }
}
