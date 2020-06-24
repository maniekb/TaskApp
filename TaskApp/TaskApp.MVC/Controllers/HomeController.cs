using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskApp.Infrastructure.Services;
using TaskApp.Models;

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
            ViewData["DateSortParm"] = sortOrder == "NumOfTasks" ? "num_desc" : "NumOfTasks";

            var data = await _taskGroupService.BrowseAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(x => x.Name).ToList();
                    break;
                case "NumOfTasks":
                    data = data.OrderBy(x => x.NumberOfTasks).ToList();
                    break;
                case "date_desc":
                    data = data.OrderByDescending(x => x.NumberOfTasks).ToList();
                    break;
                default:
                    data = data.OrderBy(x => x.Name).ToList();
                    break;
            }
            return View(data);

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
