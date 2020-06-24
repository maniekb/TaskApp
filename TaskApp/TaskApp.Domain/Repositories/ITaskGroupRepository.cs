using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Repositories
{
    public interface ITaskGroupRepository
    {
        Task<List<TaskGroup>> BrowseAsync();
    }
}
