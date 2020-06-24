using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.EF;
using Microsoft.EntityFrameworkCore.Internal;

namespace TaskApp.Infrastructure.Repositories
{
    public class TaskGroupRepository : ITaskGroupRepository
    {
        private readonly TaskAppContext _context;

        public TaskGroupRepository(TaskAppContext context)
        {
            _context = context;
        }

        public async Task<List<TaskGroup>> BrowseAsync()
            => await _context.TaskGroups.Include(t => t.UserTasks).ToListAsync();

        public async Task<TaskGroup> GetAsync(int groupId)
            => await _context.TaskGroups.SingleOrDefaultAsync(g => g.TaskGroupId == groupId);

        public async Task DeleteAsync(TaskGroup group)
        {
            _context.TaskGroups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}
