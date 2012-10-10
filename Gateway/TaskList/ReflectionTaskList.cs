using System;

namespace Gateway.TaskList
{
    public class ReflectionTaskList : ITaskList
    {
        string assemblyName, typeName, methodName;

        public ReflectionTaskList(string assemblyName, string typeName, string methodName)
        {
            this.assemblyName = assemblyName;
            this.typeName = typeName;
            this.methodName = methodName;
        }

        public bool ProcessTask(int number)
        {

            try
            {

                object o = Activator.CreateInstance(assemblyName, typeName.Replace("%n%", number.ToString())).Unwrap();
                o.GetType().GetMethod(methodName).Invoke(o, null);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
