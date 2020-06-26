using System;

namespace TaskApp.Domain.Entities
{
    public class UserTask
    {
        public int UserTaskId { get; set; }
        public int TaskGroupId { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; } 
        public int? UserId { get; set; }
        public Status Status { get; set; }

        public UserTask()
        {
        }

        public UserTask(int taskGroupId, string name, DateTime deadline, int? userId, Status status)
        {
            TaskGroupId = taskGroupId;
            Name = name;
            Deadline = deadline;
            UserId = userId;
            Status = status;
        }
    }
}