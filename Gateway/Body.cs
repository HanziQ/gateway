using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class Body
    {
        private List<string> lines = new List<string>();

        public void Clear()
        {
            lines.Clear();
            Draw();
        }

        public void AddLine(string line)
        {
            lines.Add(line);
            Draw();
        }


        public void Draw()
        {
            int bodyHeight = Console.WindowHeight - 7;
            ConsoleEx.DrawRectangle(BorderStyle.LineSingle, 0, 3, Console.WindowWidth - 1, bodyHeight, false);

            if (lines.Count > 0)
            {
                for (int i = Math.Max(0, lines.Count - bodyHeight), j = 4; i < lines.Count; i++, j++)
                {
                    ConsoleEx.WriteAt(1, j, lines[i]);
                }
            }
        }
    }
}
