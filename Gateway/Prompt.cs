using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class Prompt
    {

        public void Draw()
        {
            ConsoleEx.DrawRectangle(BorderStyle.LineSingle, 0, Console.WindowHeight - 3, Console.WindowWidth - 1, 2, false);
            ConsoleEx.WriteAt(1, Console.WindowHeight - 2, "> ");
            ConsoleEx.CursorVisible = true;
        }
    }
}
