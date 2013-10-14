using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VGateway
{
    class Matrix
    {
        int height, width;

        int[][] grid;

        public Matrix(int w, int h)
        {
            height = h;
            width = w;
            grid = new int[w][];
            for (int i = 0; i < w; i++)
            {
                grid[i] = new int[h];
            }
        }

        public int[] this[int x]
        {
            get
            {
                return grid[x];
            }
        }

        public int Get(int x, int y)
        {
            return grid[x][y];
        }

        public void Set(int x, int y, int value)
        {
            grid[x][y] = value;
        }

        public int GetMaxInRow(int row)
        {
            int max = grid[0][row];
            for (int i = 1; i < width; i++)
            {
                if (grid[i][row] > max)
                    max = grid[i][row];
            }
            return max;
        }

        public int GetSumOfRow(int row)
        {
            int sum = grid[0][row];
            for (int i = 1; i < width; i++)
            {
                sum += grid[i][row];
            }
            return sum;
        }

        public int GetMaxInCol(int col)
        {
            int max = grid[col][0];
            for (int i = 1; i < height; i++)
            {
                if (grid[col][i] > max)
                    max = grid[col][i];
            }
            return max;
        }

        public int GetSumOfCol(int col)
        {
            int sum = grid[col][0];
            for (int i = 1; i < height; i++)
            {
                sum += grid[col][i];
            }
            return sum;
        }

        public static Matrix GenerateRandom(int width, int height)
        {
            Matrix m = new Matrix(width, height);
            Random r = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    m[i][j] = r.Next(0, 20);
                }
            }

            return m;
        }

        public static Matrix GenerateDiagonal(int n)
        {
            Matrix m = new Matrix(n, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i][j] = (i == j || n - i - 1 == j) ? 1 : 0; 
                }
            }

            return m;
        }
        
    }
}
