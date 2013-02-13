using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace VGateway
{
    public class TaskList
    {
        public List<int> GetTasks()
        {
            List<int> nums = new List<int>();
            MethodInfo[] mi = GetType().GetMethods();
            foreach (MethodInfo m in mi)
            {
                Match ma = Regex.Match(m.Name, "Task(\\d+)");
                if(ma.Success)
                {
                    nums.Add(Int32.Parse(ma.Groups[1].Value));
                }
            }
            return nums;
        }

        public void Task1()
        {

        }

        public void Task2()
        {

        }

        public void Task3()
        {

        }
    }
}
