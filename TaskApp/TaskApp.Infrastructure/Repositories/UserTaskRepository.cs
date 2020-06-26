using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.EF;

namespace TaskApp.Infrastructure.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly TaskAppContext _context;

        public UserTaskRepository(TaskAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserTask task)
        {
            _context.UserTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserTask task)
        {
            _context.UserTasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserTask>> BrowseAsync(int groupId)
            => await _context.UserTasks.Where(t => t.TaskGroupId == groupId).ToListAsync();

        public async Task<UserTask> GetAsync(int taskId)
            => await _context.UserTasks.SingleOrDefaultAsync(t => t.UserTaskId == taskId);

    }
}
