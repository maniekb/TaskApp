using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public interface ITaskGroupService
    {
        Task<List<TaskGroupDTO>> BrowseAsync();
        Task<TaskGroupDTO> GetAsync(int groupId);
        Task DeleteAsync(int groupId);
        Task UpdateAsync(int groupId, string name);
        Task<int> CreateAsync(string name);
    }
}
