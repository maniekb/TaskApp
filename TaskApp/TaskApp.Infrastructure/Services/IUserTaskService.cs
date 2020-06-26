using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public interface IUserTaskService
    {
        Task<List<UserTaskDTO>> GetAsync(int groupId);
        Task CreateAsync(int taskGroupId, string name, DateTime deadline, int? userId, Status status);
        Task DeleteAsync(int taskId);
    }
}