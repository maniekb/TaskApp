using System;

namespace TaskApp.Domain.Entities
{
    public class UserTask
    {
        public int UserTaskId { get; protected set; }
        public int TaskGroupId { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Deadline { get; protected set; } 
        public int? UserId { get; protected set; }
        public Status Status { get; protected set; }

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