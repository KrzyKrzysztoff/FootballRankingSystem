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

                var teamViewModelList = await rankingService.GetNationalityName();

                teamViewModelList.MatchStatus = rankingService.GetMatchStatus();

                return View(teamViewModelList);
        }

        [HttpPost]
        public async Task<IActionResult> Simulation(TeamViewModel teamViewModel)
        {
            
            SimulationDto simulationDto = new SimulationDto()
            {
                MatchStatusName = teamViewModel.MatchStatusName,
                NameTeamX = teamViewModel.TeamX,
                NameTeamY = teamViewModel.TeamY
            };

            var matchResult = await rankingService.CreateSimulation(simulationDto);
            return RedirectToAction("MatchResult", matchResult);
           
        }
        
        [HttpGet]
        public IActionResult MatchResult(MatchResultViewModel matchResult)
        {
            return View(matchResult);
        }


       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       [Route("error")]
        public IActionResult Error()
        {
           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
