using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Repositories
{
    public interface IUserTaskRepository
    {
        Task<List<UserTask>> BrowseAsync(int groupId);
        Task<UserTask> GetAsync(int groupId);
        Task AddAsync(UserTask task);
        Task DeleteAsync(UserTask task);
    }
}
