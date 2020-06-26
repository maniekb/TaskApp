using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.EF;

namespace TaskApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskAppContext _context;

        public UserRepository(TaskAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> BrowseAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetAsync(int userId)
            => await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
