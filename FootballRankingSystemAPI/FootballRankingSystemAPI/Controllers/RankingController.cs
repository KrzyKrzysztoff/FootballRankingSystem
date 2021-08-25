using FootballRankingSystemAPI.Entities;
using FootballRankingSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Controllers
{

    [ApiController]
    [Route("api/ranking")]
    public class RankingController : Controller
    {
        private readonly IRankingService rankingService;

        public RankingController(IRankingService rankingService)
        {
            this.rankingService = rankingService;
        }

        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var teams = rankingService.GetAll();

            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }
    }
}
