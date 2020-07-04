using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevLifeMvc.Models;
using DevLifeMvc.Services;

namespace DevLifeMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoryService _stories;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IStoryService storyService)
        {
            _logger = logger;
            _stories = storyService;
        }

        public async Task<ActionResult> Index()
        {
            var res = await _stories.Get();
            return View(res.ToList());
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
