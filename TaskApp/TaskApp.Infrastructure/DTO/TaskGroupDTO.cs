using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.Infrastructure.DTO
{
    public class TaskGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTasks { get; set; }
    }
}
