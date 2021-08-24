using FootballRankingSystemAPI.Model;
using FootballRankingSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/simulation")]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService simulationService;

        public SimulationController(ISimulationService simulationService)
        {
            this.simulationService = simulationService;
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] SimulationDto simulationDto)
        {
           var result = simulationService.Simulation(simulationDto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
