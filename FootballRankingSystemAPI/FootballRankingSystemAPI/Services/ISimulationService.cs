using FootballRankingSystemAPI.Entities;
using FootballRankingSystemAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Services
{
    public interface ISimulationService
    {
        MatchResult Simulation(SimulationDto simulationDto);
    }
}
