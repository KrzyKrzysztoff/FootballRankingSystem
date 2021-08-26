using FootballRankingSystemAPI.Entities;
using FootballRankingSystemAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Services
{
    public class RankingService : IRankingService
    {
        private readonly RankingDbContext rankingDbContext;

        public RankingService(RankingDbContext rankingDbContext)
        {
            this.rankingDbContext = rankingDbContext;
        }

        public List<TeamDto> GetAll()
        {
            var teams = rankingDbContext.Team.ToList();

            List<TeamDto> teamDtoList = new List<TeamDto>();

            foreach (var item in teams)
            {
                TeamDto teamDto = new TeamDto();
                teamDto.Name = item.Name;
                teamDto.Points = item.Points;
                teamDto.RankingPlace = item.RankingPlace;
                teamDtoList.Add(teamDto);
            }

            var teamDtoListSorted = teamDtoList.OrderBy(x => x.RankingPlace).ToList();

            return teamDtoListSorted;

        }
    }
}
