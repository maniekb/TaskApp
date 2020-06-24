using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public class TaskGroupService : ITaskGroupService
    {
        private readonly ITaskGroupRepository _taskGroupRepository;

        public TaskGroupService(ITaskGroupRepository taskGroupRepository)
        {
            _taskGroupRepository = taskGroupRepository;
        }

        public async Task<List<TaskGroupDTO>> BrowseAsync()
        {
            var taskGroups = await _taskGroupRepository.BrowseAsync();

            var query = taskGroups.Select(t => new TaskGroupDTO
            {
                Id = t.TaskGroupId,
                Name = t.Name,
                NumberOfTasks = t.UserTasks.Count()
            }).ToList();

            return query;
        }
    }
}
