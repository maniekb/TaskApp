using System.Collections.Generic;

namespace TaskApp.Domain.Entities
{
    public class TaskGroup
    {
        public int TaskGroupId { get; set; }
        public string Name { get; set; }
        public IList<UserTask> UserTasks { get; set; }
    }
}
