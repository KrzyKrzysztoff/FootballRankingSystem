using FootballRankingSystemAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Controllers
{
    public class RankingController : Controller
    {
      

        public RankingController(RankingDbContext rankingDbContext)
        {
         
        }
        public IActionResult Get()
        {
            return View();
        }
    }
}
