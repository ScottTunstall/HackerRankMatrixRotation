using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankMatrixRotation
{
    class Program
    {

        static void matrixRotation(List<List<int>> matrix, int r)
        {
            var maxRows = matrix.Count;
            var maxColumns = matrix.Max(x=>x.Count);

            var newMatrix = new List<List<int>>();
            for (int i = 0; i < maxRows; i++)
                newMatrix.Add(new List<int>(new int[maxColumns]));

            var minColumn = 0;
            var maxColumn = maxColumns-1;
            var minRow = 0;
            var maxRow = maxRows - 1;

            var q = new Stack<int>();
                       
            while (minColumn < maxColumn)
            {
                for (int i = maxColumn; i >= minColumn; i--)
                    q.Push(matrix[minRow][i]);

                for (int i = minRow + 1; i <= maxRow; i++)
                    q.Push(matrix[i][minColumn]);

                for (int i = minColumn + 1; i <= maxColumn; i++)
                    q.Push(matrix[maxRow][i]);

                for (int i = maxRow - 1; i > minRow; i--)
                    q.Push(matrix[i][maxColumn]);


                // Now update the new matrix
                for (int i = minRow; i <= maxRow; i++)
                    newMatrix[i][maxColumn] = q.Pop();

                for (int i = maxColumn - 1; i >= minColumn; i--)
                    newMatrix[maxRow][i] = q.Pop();

                for (int i = maxRow - 1; i > minRow; i--)
                    newMatrix[i][minColumn] = q.Pop();

                for (int i = minColumn; i < maxColumn; i++)
                    newMatrix[minRow][i] = q.Pop();

                minColumn++;
                maxColumn--;

                minRow++;
                maxRow--;
            }
        }

        static void Main(string[] args)
        {
            //string[] mnr = Console.ReadLine().TrimEnd().Split(' ');

            //int m = Convert.ToInt32(mnr[0]);

            //int n = Convert.ToInt32(mnr[1]);

            //int r = Convert.ToInt32(mnr[2]);

            List<List<int>> matrix = new List<List<int>>();

            matrix.Add (new List<int>(new int[] {1, 2, 3, 4 }));
            matrix.Add (new List<int>(new int[] { 7, 8, 9, 10 }));
            matrix.Add (new List<int>(new int[] { 13, 14, 15, 16 }));
            matrix.Add (new List<int>(new int[] { 19, 20, 21, 22 }));
            matrix.Add(new List<int>(new int[] { 25, 26, 27, 28 }));


            //matrix.Add (new List<int>(new int[] {1, 2, 3, 4 }));
            //matrix.Add (new List<int>(new int[] { 12, 1, 2, 5 }));
            //matrix.Add (new List<int>(new int[] { 11, 4, 3, 6 }));
            //matrix.Add (new List<int>(new int[] { 10, 9, 8, 7 }));

            int r = 1;


            //for (int i = 0; i < m; i++)
            //{
            //    matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //}

            matrixRotation(matrix, r);
        }
    }
}
