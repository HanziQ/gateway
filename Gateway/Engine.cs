using System;
using System.Collections.Generic;
using System.Text;
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

        static bool noTaskFound = true;

        static bool writeHeader = true;

        static string header = "Pro spuštění úlohy zadejte její číslo a stiskněte Enter.";

        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                if (writeHeader)
                {
                    Console.WriteLine(header);
                    writeHeader = false;
                }
                string line = ReadLine();
                int number;
                if (int.TryParse(line, out number))
                {
                    try
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
                    }
                    catch (InterruptException)
                    {

                    }
                    Console.Clear();
                    writeHeader = true;
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
