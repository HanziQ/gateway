using System;
using System.Text;
using System.Collections.Generic;
using Gateway.TaskList;

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
        static List<ITaskList> taskLists = new List<ITaskList>();

        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool noTaskFound = true;

            while (true)
            {
                Console.WriteLine("Pro spuštění úlohy zadejte její číslo a stiskněte Enter.");
                string line = ReadLine();
                int number;
                if (int.TryParse(line, out number))
                {
                    foreach (ITaskList taskList in taskLists)
                    {
                        noTaskFound = true;
                        if (taskList.ProcessTask(number))
                        {
                            noTaskFound = false;
                            break;
                        }
                    }
                    if (noTaskFound)
                    {
                        WriteErrorLine("Úloha nebyla nalezena.");
                        
                        continue;
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        }

        public static void AddTaskList(ITaskList taskList)
        {
            taskLists.Add(taskList);
        }

        public static string ReadLine()
        {
            Console.Write(">");
            return Console.ReadLine();
        }

        public static void WriteErrorLine(string p)
        {
            ConsoleEx.TextColor(ConsoleForeground.White, ConsoleBackground.Red);
            Console.WriteLine(p);
            ConsoleEx.ResetColor();
        }
    }
}
