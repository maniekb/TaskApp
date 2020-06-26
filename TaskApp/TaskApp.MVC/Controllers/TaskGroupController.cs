using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Infrastructure.Services;
using TaskApp.MVC.Models;

namespace TaskApp.MVC.Controllers
{
    public class TaskGroupController : Controller
    {
        private readonly IUserTaskService _userTaskService;
        private readonly ITaskGroupService _taskGroupService;
        private readonly IUserService _userService;

        public TaskGroupController(IUserTaskService userTaskService, ITaskGroupService taskGroupService, IUserService userService)
        {
            _userTaskService = userTaskService;
            _taskGroupService = taskGroupService;
            _userService = userService;
        }

        public async Task<IActionResult> Create()
        {
            return View(new TaskGroupModel());
        }

        public async Task<IActionResult> Edit(int groupId)
        {
            var group = await _taskGroupService.GetAsync(groupId);
            var users = await _userService.BrowseAsync();

            var taskGroup = new TaskGroupModel()
            {
                Id = group.TaskGroupId,
                Name = group.Name,
                UserTasks = group.UserTasks.Select(t => new UserTaskModel
                {
                    UserTaskId = t.UserTaskId,
                    TaskGroupId = t.TaskGroupId,
                    Name = t.Name,
                    Deadline = t.Deadline,
                    Status = t.Status.ToString(),
                    UserId = t.UserId
                }).ToList()
            };

            var model = new EditModel()
            {
                TaskGroup = taskGroup,
                UserTask = new UserTaskModel(),
                Users = users.Select(u => new UserModel 
                { 
                    UserId = u.UserId,
                    Firstname = u.FirstName,
                    Lastname = u.LastName
                }).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CreateGroup(TaskGroupModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var name = model.Name;

            var id = await _taskGroupService.CreateAsync(name);

            return RedirectToAction("Edit", "TaskGroup", new { groupId = id });
        }

        public async Task<IActionResult> AddTask(EditModel model)
        {
            var task = model.UserTask;

            await _userTaskService.CreateAsync(task.TaskGroupId, task.Name, task.Deadline, task.UserId, (Status)Int32.Parse(task.Status));

            return RedirectToAction("Edit", "TaskGroup", new { groupId = task.TaskGroupId});
        }

        public async Task<IActionResult> DeleteTask(int taskId, int groupId)
        {
            await _userTaskService.DeleteAsync(taskId);

            return RedirectToAction("Edit", "TaskGroup", new { groupId = groupId });
        }

        public async Task<IActionResult> ChangeName(EditModel model)
        {
            var id = model.TaskGroup.Id;
            var name = model.TaskGroup.Name;

            await _taskGroupService.UpdateAsync(id, name);

            return RedirectToAction("Edit", "TaskGroup", new { groupId = id });
        }
    }
}