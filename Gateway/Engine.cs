using System;
using System.Text;
using System.Collections.Generic;

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

        public static Header Header = new Header();

        public static Body Body = new Body();

        public static Prompt Prompt = new Prompt();

        private static string _title = "";

        public static string Title
        {
         get{
             return _title;
         }
            set
            {
                _title = value;
                ConsoleEx.Title = CompleteTitle;
                Header.Draw();
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

        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Body.AddLine("Pro spuštění úlohy zadejte její číslo a stiskněte Enter.");

            Header.Draw();
            Body.Draw();
            Prompt.Draw();


                while (true)
                {
                    string line = ReadLine();
                    int number;
                    if(int.TryParse(line, out number))
                    {
                        ITask task = (ITask)(Activator.CreateInstance("TestApplication", "TestApplication.Tasks.Task" + number).Unwrap());
                        task.Process();
                        Console.ReadLine();
                    }
                }

  
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
