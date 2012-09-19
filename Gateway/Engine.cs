using System;
using System.Text;

namespace Gateway
{
    public enum State
    {
        Menu,
        List,
        Task
    }

    public static class Engine
    {
        public static State State = State.Menu;

        private static string _title = "";

        public static string Title
        {
         get{
             return _title;
         }
            set
            {
                _title = value;
                Console.Title = CompleteTitle;
                WriteHeader(CompleteTitle);
            }
        }

        public static string BaseTitle;

        public static string CompleteTitle
        {
            get
            {
                return BaseTitle + (Title == "" ? "" : " - " + Title);
            }
        }

        public static int ScrollPosition = 0;

        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            WriteHeader(CompleteTitle);
            //WriteBody();
                
            Console.ReadLine();

        }

        public static void WriteHeader(string title)
        {
            SaveCursor();
            Console.SetCursorPosition(0, 0);

            if (title.Length > Console.WindowWidth - 4)
            {
                title = title.Remove(Console.WindowWidth - 7) + "...";
            }            

            Console.Write((char)0x2554);
            Console.Write(new String((char)0x2550,Console.WindowWidth-2));
            Console.Write((char)0x2557);

            Console.Write((char)0x2551);
            int before = Console.WindowWidth / 2 - title.Length / 2;
            Console.CursorLeft = before;
            Console.Write(title);
            Console.CursorLeft = Console.WindowWidth-1;
            Console.Write((char)0x2551);

            Console.Write((char)0x255A);
            Console.Write(new String((char)0x2550, Console.WindowWidth - 2));
            Console.Write((char)0x255D);

            RestoreCursor();
        }

        public static void WriteBody(StringBuilder builder)
        {
            SaveCursor();
            Console.SetCursorPosition(3, 0);

            string[] lines = builder.ToString().Split('\n');
            

            RestoreCursor();
        }

        public static void WritePrompt()
        {
            Console.CursorTop = Console.WindowHeight - 3;
            Console.WriteLine("Zadejte číslo úlohy:");
            Console.Write(new String('-', Console.WindowWidth));
            Console.Write('>');
        }

        static int left, top;

        public static void SaveCursor()
        {
            left = Console.CursorLeft;
            top = Console.CursorTop;
        }

        public static void RestoreCursor()
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
