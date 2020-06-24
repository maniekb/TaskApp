using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.Domain.Entities;

namespace TaskApp.Infrastructure.EF
{
    public class TaskAppContext : DbContext
    {
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskAppContext(DbContextOptions<TaskAppContext> options)
         : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
