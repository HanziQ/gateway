using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway.TaskList
{
    public class ReflectionTaskList : ITaskList
    {
        string assemblyName, namespaceName;

        public ReflectionTaskList(string assemblyName, string namespaceName)
        {
            this.assemblyName = assemblyName;
            this.namespaceName = namespaceName;
        }

        public bool ProcessTask(int number)
        {
            ITask task;
            try
            {
                task = (ITask)(Activator.CreateInstance(assemblyName, namespaceName + ".Task" + number).Unwrap());
            }
            catch (TypeLoadException)
            {
                return false;
            }            
            task.Process();
            return true;
        }
    }
}
