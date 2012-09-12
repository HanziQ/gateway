using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Gateway
{
    public class Main
    {
        private ITaskList taskList;

        public Main(ITaskList taskList)
        {
            this.taskList = taskList;
            Run();
        }

        private void Run()
        {
            WriteHeader();
            WritePrompt();
            string read = Console.ReadLine();

            Console.Clear();

            int taskID;
            if (int.TryParse(read, out taskID))
            {
                MethodInfo method = taskList.GetType().GetMethod("Task" + taskID.ToString());
                if (method != null)
                {
                    method.Invoke(taskList, null);
                }
            }
        }

        string title = "Gateway";

        private void WriteHeader()
        {
            Console.Write(new String('=', Console.WindowWidth));
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
