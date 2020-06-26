using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public class TaskGroupService : ITaskGroupService
    {
        private readonly ITaskGroupRepository _taskGroupRepository;
        private readonly IMapper _mapper;

        public TaskGroupService(ITaskGroupRepository taskGroupRepository, IMapper mapper)
        {
            _taskGroupRepository = taskGroupRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskGroupDTO>> BrowseAsync()
        {
            var taskGroups = await _taskGroupRepository.BrowseAsync();

            return _mapper.Map<List<TaskGroup>, List<TaskGroupDTO>>(taskGroups);
        }

        public async Task<int> CreateAsync(string name)
        {
            var group = new TaskGroup(name);
            var id = await _taskGroupRepository.AddAsync(group);

            return id;
        }

        public async Task DeleteAsync(int groupId)
        {
            var group = await _taskGroupRepository.GetAsync(groupId);
            await _taskGroupRepository.DeleteAsync(group);
        }

        public async Task<TaskGroupDTO> GetAsync(int groupId)
        {
            var taskGroup = await _taskGroupRepository.GetAsync(groupId);

            return _mapper.Map<TaskGroup, TaskGroupDTO>(taskGroup);
        }

        public async Task UpdateAsync(int groupId, string name)
        {
            var group = await _taskGroupRepository.GetAsync(groupId);
            group.Name = name;

            await _taskGroupRepository.UpdateAsync(group);
        }
    }
}
