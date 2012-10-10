using System;

namespace Gateway.TaskList
{
    public class ReflectionTaskList : ITaskList
    {
        string assemblyName, typeName;

        public ReflectionTaskList(string assemblyName, string typeName)
        {
            this.assemblyName = assemblyName;
            this.typeName = typeName;
        }

        public bool ProcessTask(int number)
        {
            ITask task;
            try
            {
                task = (ITask)(Activator.CreateInstance(assemblyName, typeName + number).Unwrap());
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
