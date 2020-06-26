using System;
using TaskApp.Domain.Entities;

namespace TaskApp.Infrastructure.DTO
{
    public class UserTaskDTO
    {
        public int UserTaskId { get; set; }
        public int TaskGroupId { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int? UserId { get; set; }
        public Status Status { get; set; }
    }
}
