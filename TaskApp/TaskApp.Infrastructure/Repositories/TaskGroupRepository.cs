using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<IEnumerable<TaskGroup>> BrowseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
