using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.Domain.Entities
{
    public class TaskGroup
    {
        public int TaskGroupId { get; set; }
        public string Name { get; set; }
        public IList<UserTask> UserTasks { get; set; }
    }
}
