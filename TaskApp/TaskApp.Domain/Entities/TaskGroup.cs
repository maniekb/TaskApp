using System.Collections.Generic;

namespace TaskApp.Domain.Entities
{
    public class TaskGroup
    {
        public int TaskGroupId { get; protected set; }
        public string Name { get; set; }
        public IList<UserTask> UserTasks { get; protected set; }

        public TaskGroup()
        {
        }

        public TaskGroup(string name)
        {
            Name = name;
        }
    }
}
