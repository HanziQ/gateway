using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task9 : ITask
    {
        public void Process()
        {
            Console.WriteLine("Zadejte 3 čísla pro seřazení.");
            List<int> nums = new List<int>();
            nums.Add(Input<int>.Get(""));
            nums.Add(Input<int>.Get(""));
            nums.Add(Input<int>.Get(""));

            nums.Sort();

            Console.WriteLine("Seřazená čísla jsou - " + nums[0] + "," + nums[1] + "," + nums[2] + ".");
            
        }
    }
}
