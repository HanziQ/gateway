using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    class IntegerTable : Table<int>
    {
        protected int[,] inverseValues;

        public IntegerTable(int[,] values)
            : base(values)
        {
            inverseValues = Inverse();
        }

        public IntegerTable(int h, int w)
            :base(h, w)
        {
            inverseValues = new int[w, h];
        }

        public IntegerTable(int size)
            : base(size)
        {
            inverseValues = new int[size, size] ;
        }

        public new int this[int h, int w]
        {
            set
            {
                values[h, w] = value;
                inverseValues[w, h] = value;
            }
            get
            {
                return values[h, w];
            }
        }

        private string GetDataInTableFormatWithMaxMin()
        {
            string formattedString = string.Empty;

            if (values == null)
                return formattedString;

            int maxCellWidth = GetMaxCellWidth();
            int indentLength = (Width * maxCellWidth) + (Width - 1);
            //printing top line;
            formattedString = string.Format("{0}{1}{2}{3}", cellLeftTop, Indent(indentLength), cellRightTop, System.Environment.NewLine);

            for (int i = 0; i < Height; i++)
            {
                string lineWithValues = cellVerticalLine;
                string line = cellVerticalJointLeft;
                for (int j = 0; j < Width; j++)
                {
                    string value = (isLeftAligned) ? values[i, j].ToString().PadRight(maxCellWidth, ' ') : values[i, j].ToString().PadLeft(maxCellWidth, ' ');
                    lineWithValues += string.Format("{0}{1}", value, cellVerticalLine);
                    line += Indent(maxCellWidth);
                    if (j < (Width - 1))
                    {
                        line += cellTJoint;
                    }
                }
                line += cellVerticalJointRight;
                formattedString += string.Format("{0} {1} {2} {3}", lineWithValues, GetRowMinimum(i), GetRowMaximum(i), System.Environment.NewLine);
                if (i < (Height - 1))
                {
                    formattedString += string.Format("{0}{1}", line, System.Environment.NewLine);
                }
            }

            //printing bottom line
            formattedString += string.Format("{0}{1}{2}{3}", cellLeftBottom, Indent(indentLength), cellRightBottom, System.Environment.NewLine);
            return formattedString;
        }

        private int[,] Inverse()
        {
            int[,] inversed = new int[Width + 1, Height + 1];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    inversed[i, j] = values[j, i];
                }
            }
            return inversed;
        }

        private int GetRowMinimum(int row)
        {
            return (from col in Enumerable.Range(0, values.GetLength(1))
            select values[row, col]).Min();
        }

        private int GetRowMaximum(int row)
        {
            return (from col in Enumerable.Range(0, values.GetLength(1))
                    select values[row, col]).Max();
        }

        private int GetColumnMinimum(int col)
        {
            return (from row in Enumerable.Range(0, values.GetLength(0))
                    select values[row, col]).Min();
        }

        private int GetColumnMaximum(int col)
        {
            return (from row in Enumerable.Range(0, values.GetLength(0))
                    select values[row, col]).Max();
        }

        public void PrintToConsoleWithMaxMin()
        {
            if (values == null)
                return;

            Console.WriteLine(GetDataInTableFormatWithMaxMin());
        }
    }
}
