using FootballRankingSystemMVC.Models;
using FootballRankingSystemMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRankingService rankingService;

        public HomeController(ILogger<HomeController> logger,  IRankingService rankingService)
        {
            _logger = logger;
            this.rankingService = rankingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var teamList = await rankingService.GetRanking();

            return View(teamList);
        }

        [HttpGet]
        public async Task<IActionResult> Simulation()
        {
            var nationalityList = await rankingService.GetNationalityName();

            return View(nationalityList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
