
using Gateway;
using System;
using TestApplication.Tasks;
using Gateway.TaskList;
namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Engine.AddTaskList(new ReflectionTaskList("TestApplication", "TestApplication.Tasks"));
            Engine.Start();  
        }
    }
}
