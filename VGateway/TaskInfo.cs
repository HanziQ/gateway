using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VGateway
{
    class TaskInfo
    {
        public int ID { get; private set; }
        public string Description { get; private set;}
        public Type Type { get; private set; }

        public TaskInfo(int id, string description, Type type)
        {
            this.ID = id;
            this.Description = description;
            this.Type = type;
        }
    }
}
