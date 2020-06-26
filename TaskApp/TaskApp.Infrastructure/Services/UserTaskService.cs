using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IMapper _mapper;

        public UserTaskService(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            _userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }


        public async Task<List<UserTaskDTO>> GetAsync(int groupId)
        {
            var tasks = await _userTaskRepository.BrowseAsync(groupId);
            
            return _mapper.Map<List<UserTask>, List<UserTaskDTO>>(tasks);
        }

        public async Task CreateAsync(int taskGroupId, string name, DateTime deadline, int? userId, Status status)
        {
            var task = new UserTask(taskGroupId, name, deadline, userId, status);
            await _userTaskRepository.AddAsync(task);

        }

        public async Task DeleteAsync(int taskId)
        {
            var task = await _userTaskRepository.GetAsync(taskId);
            await _userTaskRepository.DeleteAsync(task);
        }
    }
}
