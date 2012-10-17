
using System;
using Gateway;
using Gateway.TaskList;
namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Engine.AddTaskList(new ReflectionTaskList("TestApplication", "TestApplication.Tasks.Task%n%", "Process"));
            Engine.AddTaskList(new ReflectionTaskList("TestApplication", "TestApplication.Tasks.Tasks", "Process%n%"));
            Engine.Start();
        }
    }
}
