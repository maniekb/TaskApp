using System.Collections.Generic;

namespace TaskApp.Infrastructure.DTO
{
    public class TaskGroupDTO
    {
        public int TaskGroupId { get; set; }
        public string Name { get; set; }
        public IList<UserTaskDTO> UserTasks { get; set; }
    }
}
