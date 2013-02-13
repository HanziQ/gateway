using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestApplication
{
    public class Table<T>
    {
        #region Declarations

        protected static bool isLeftAligned = false;
        protected const string cellLeftTop = "┌";
        protected const string cellRightTop = "┐";
        protected const string cellLeftBottom = "└";
        protected const string cellRightBottom = "┘";
        protected const string cellHorizontalJointTop = "┬";
        protected const string cellHorizontalJointbottom = "┴";
        protected const string cellVerticalJointLeft = "├";
        protected const string cellTJoint = "┼";
        protected const string cellVerticalJointRight = "┤";
        protected const string cellHorizontalLine = "─";
        protected const string cellVerticalLine = "│";

        #endregion

        protected T[,] values;

        public Table(T[,] values)
        {
            this.values = values;

        }

        public Table(int h, int w)
        {
            if (w <= 0 || h <= 0)
                throw new Exception("Cannot create this table.");
            values = new T[h, w];
        }

        public Table(int size)
            : this(size, size)
        {
        }

        public T this[int h, int w]
        {
            set
            {
                values[h, w] = value;
            }
            get
            {
                return values[h, w];
            }
        }

        public int Width
        {
            get
            {
                return values.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return values.GetLength(0);
            }
        }

        #region Private Methods

        protected int GetMaxCellWidth()
        {
            int maxWidth = 1;

            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    int length = values[i, j].ToString().Length;
                    if (length > maxWidth)
                    {
                        maxWidth = length;
                    }
                }
            }

            return maxWidth;
        }

        protected string GetDataInTableFormat()
        {
            string formattedString = string.Empty;

            if (values == null)
                return formattedString;

            int dimension1Length = values.GetLength(0);
            int dimension2Length = values.GetLength(1);

            int maxCellWidth = GetMaxCellWidth();
            int indentLength = (dimension2Length * maxCellWidth) + (dimension2Length - 1);
            //printing top line;
            formattedString = string.Format("{0}{1}{2}{3}", cellLeftTop, Indent(indentLength), cellRightTop, System.Environment.NewLine);

            for (int i = 0; i < dimension1Length; i++)
            {
                string lineWithValues = cellVerticalLine;
                string line = cellVerticalJointLeft;
                for (int j = 0; j < dimension2Length; j++)
                {
                    string value = (isLeftAligned) ? values[i, j].ToString().PadRight(maxCellWidth, ' ') : values[i, j].ToString().PadLeft(maxCellWidth, ' ');
                    lineWithValues += string.Format("{0}{1}", value, cellVerticalLine);
                    line += Indent(maxCellWidth);
                    if (j < (dimension2Length - 1))
                    {
                        line += cellTJoint;
                    }
                }
                line += cellVerticalJointRight;
                formattedString += string.Format("{0}{1}", lineWithValues, System.Environment.NewLine);
                if (i < (dimension1Length - 1))
                {
                    formattedString += string.Format("{0}{1}", line, System.Environment.NewLine);
                }
            }

            //printing bottom line
            formattedString += string.Format("{0}{1}{2}{3}", cellLeftBottom, Indent(indentLength), cellRightBottom, System.Environment.NewLine);
            return formattedString;
        }

        protected string Indent(int count)
        {
            return string.Empty.PadLeft(count, '─');
        }

        #endregion

        #region Public Methods

        public void PrintToStream(StreamWriter writer)
        {
            if (values == null)
                return;

            if (writer == null)
                return;

            writer.Write(GetDataInTableFormat());
        }

        public void PrintToConsole()
        {
            if (values == null)
                return;

            Console.WriteLine(GetDataInTableFormat());
        }
        #endregion
    }
}
