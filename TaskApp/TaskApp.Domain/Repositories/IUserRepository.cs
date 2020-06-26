using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(int id);
        Task<List<User>> BrowseAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
