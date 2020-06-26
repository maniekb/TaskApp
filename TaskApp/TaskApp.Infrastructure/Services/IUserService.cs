using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> BrowseAsync();
        Task<UserDTO> GetAsync(int userId);
        Task AddAsync(string firstname, string lastname);
        Task UpdateAsync(int userId, string firstname, string lastname);
        Task DeleteAsync(int userId);
    }
}
