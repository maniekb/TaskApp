using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public interface ITaskGroupService
    {
        Task<List<TaskGroupDTO>> BrowseAsync();
        Task DeleteAsync(int id);
    }
}
