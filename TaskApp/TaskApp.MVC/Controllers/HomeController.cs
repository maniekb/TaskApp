using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Infrastructure.Services;
using TaskApp.Models;
using TaskApp.MVC.Models;

namespace TaskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskGroupService _taskGroupService;

        public HomeController(ILogger<HomeController> logger, ITaskGroupService taskGroupService)
        {
            _logger = logger;
            _taskGroupService = taskGroupService;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NoOfTasksSortParm"] = sortOrder == "num_asc" ? "num_desc" : "num_asc";

            var groups = await _taskGroupService.BrowseAsync();

            var models = groups.Select(m => new IndexModel
            {
                GroupId = m.TaskGroupId,
                Name = m.Name,
                UserTasksCount = m.UserTasks.Count()
            });

            switch (sortOrder)
            {
                case "name_desc":
                    models = models.OrderByDescending(x => x.Name).ToList();
                    break;
                case "num_asc":
                    models = models.OrderBy(x => x.UserTasksCount).ToList();
                    break;
                case "num_desc":
                    models = models.OrderByDescending(x => x.UserTasksCount).ToList();
                    break;
                default:
                    models = models.OrderBy(x => x.Name).ToList();
                    break;
            }
            return View(models);
        }

        public async Task<IActionResult> Delete(int groupId)
        {
            await _taskGroupService.DeleteAsync(groupId);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
