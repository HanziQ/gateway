using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway.TaskList
{
    public interface ITaskList
    {
        bool ProcessTask(int number);
    }
}
