using System;

namespace Gateway
{
    public enum State
    {
        Menu,
        List,
        Task
    }

    public class Main
    {
        public State State = State.Menu;

        public Renderer Renderer
        {
            get;
            private set;
        }

        string title, body;

        public Main(string title, string body)
        {
            this.title = title;
            this.body = body;
            Console.Title = title;

            Renderer = new Renderer();
            Renderer.Title = title;
            Renderer.Body = body;
        }

        private void WriteHeader()
        {
            Console.Write(new String((char)219, Console.WindowWidth));
            int before = Console.WindowWidth / 2 - title.Length / 2;
            Console.CursorLeft = before;
            Console.WriteLine(title);
            Console.CursorLeft = 0;
            Console.WriteLine(new String('=', Console.WindowWidth));
        }

        private void WritePrompt()
        {
            Console.CursorTop = Console.WindowHeight - 3;
            Console.WriteLine("Zadejte číslo úlohy:");
            Console.Write(new String('-', Console.WindowWidth));
            Console.Write('>');
        }
    }
}
