using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankMatrixRotation
{
    class Program
    {

        // Returns matrix rotated anticlockwise R times 
        static List<List<int>> matrixRotation(List<List<int>> matrix, int r)
        {
            var maxRows = matrix.Count;
            var maxColumns = matrix.Max(x => x.Count);

            // Clone
            var newMatrix = new List<List<int>>();
            for (int i = 0; i < maxRows; i++)
                newMatrix.Add(new List<int>(matrix[i]));

        

            var q = new Stack<int>();

            for (int rotations = 0; rotations < r; rotations++)
            {
                // define rect to work on
                var left = 0;
                var right = maxColumns - 1;
                var top = 0;
                var bottom = maxRows - 1;

                while (left < right)
                {
                    for (int i = right; i >= left; i--)
                        q.Push(newMatrix[top][i]);

                    for (int i = top + 1; i <= bottom; i++)
                        q.Push(newMatrix[i][left]);

                    for (int i = left + 1; i <= right; i++)
                        q.Push(newMatrix[bottom][i]);

                    for (int i = bottom - 1; i > top; i--)
                        q.Push(newMatrix[i][right]);


                    // Now update the new matrix
                    for (int i = top; i <= bottom; i++)
                        newMatrix[i][right] = q.Pop();

                    for (int i = right - 1; i >= left; i--)
                        newMatrix[bottom][i] = q.Pop();

                    for (int i = bottom - 1; i > top; i--)
                        newMatrix[i][left] = q.Pop();

                    for (int i = left; i < right; i++)
                        newMatrix[top][i] = q.Pop();

                    left++;
                    right--;

                    top++;
                    bottom--;
                }
            }

            return newMatrix;
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

            int r = 3;


            //for (int i = 0; i < m; i++)
            //{
            //    matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //}

            var newMatrix = matrixRotation(matrix, r);

            foreach (var row in newMatrix)
            {
                var asArray = row.ToArray();
                Console.WriteLine(string.Join(' ', asArray));
            }

            Console.ReadLine();
        }
    }
}
