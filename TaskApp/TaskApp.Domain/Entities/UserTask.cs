using System;

namespace TaskApp.Domain.Entities
{
    public class UserTask
    {
        public int UserTaskId { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; } 
        public int? UserId { get; set; }
        public Status Status { get; set; }
    }
}