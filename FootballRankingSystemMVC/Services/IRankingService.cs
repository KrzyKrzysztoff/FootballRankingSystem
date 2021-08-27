using FootballRankingSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC.Services
{
    public interface IRankingService
    {
        Task<List<RankingViewModel>> GetRanking();
        Task<TeamViewModel> GetNationalityName();
        List<MatchStatus> GetMatchStatus();
        Task<MatchResultViewModel> CreateSimulation(SimulationDto simulationDto);
    }
}
