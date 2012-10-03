using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class Header
    {

        public void Draw()
        {
            string title = Engine.CompleteTitle;
            if (title.Length > Console.WindowWidth - 4)
            {
                title = title.Remove(Console.WindowWidth - 7) + "...";
            }

            ConsoleEx.DrawRectangle(BorderStyle.LineDouble, 0, 0, Console.WindowWidth - 1, 2, false);
            int x = Console.WindowWidth / 2 - title.Length / 2;
            ConsoleEx.WriteAt(x, 1, title);           
        }
    }
}
