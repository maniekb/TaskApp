using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.EF;

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
            => await _context.TaskGroups.Include(g => g.UserTasks).ToListAsync();

        public async Task<TaskGroup> GetAsync(int groupId)
            => await _context.TaskGroups.Include(g => g.UserTasks).SingleOrDefaultAsync(g => g.TaskGroupId == groupId);

        public async Task DeleteAsync(TaskGroup group)
        {
            _context.TaskGroups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskGroup group)
        {
            _context.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AddAsync(TaskGroup group)
        {
            _context.TaskGroups.Add(group);
            await _context.SaveChangesAsync();

            return group.TaskGroupId;
        }
    }
}
