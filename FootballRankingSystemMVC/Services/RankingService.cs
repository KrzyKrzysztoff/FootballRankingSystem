using FootballRankingSystemMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace FootballRankingSystemMVC.Services
{
    public class RankingService : IRankingService
    {
        List<RankingViewModel> rankingViewModels = new List<RankingViewModel>();

        public async Task<List<RankingViewModel>> GetRanking()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/ranking/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    rankingViewModels = JsonConvert.DeserializeObject<List<RankingViewModel>>(apiResponse);
                }
            }

            return rankingViewModels;
        }

        public async Task<TeamViewModel> GetNationalityName()
        {

            var teamViewModel = new TeamViewModel();

            var teamList = await GetRanking();

            var nationalityList = teamList.Select(x => new Team()
            { Name = x.Name });

            List<Team> teams = new List<Team>();

            teams.AddRange(nationalityList);

            teamViewModel.Teams = teams;

            return teamViewModel;
        }

        public List<MatchStatus> GetMatchStatus()
        {
            List<MatchStatus> matchStatusList = new List<MatchStatus>()
            {
                new MatchStatus { Name = "FifaWorldFinal"},
                new MatchStatus { Name = "ContinentalCupFinal"},
                new MatchStatus { Name = "FifaWorld_ContinentalCup"},
                new MatchStatus { Name = "FriendlyMatch"},
            };

            return matchStatusList;
        }

        public async Task<MatchResultViewModel> CreateSimulation(SimulationDto simulationDto)
        {
            MatchResultViewModel matchResultViewModel = new MatchResultViewModel();

            using (var httpClinet = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(simulationDto), Encoding.UTF8, "application/json");

                using (var response = await httpClinet.PostAsync("https://localhost:5001/api/simulation/create", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    matchResultViewModel = JsonConvert.DeserializeObject<MatchResultViewModel>(apiResponse);
                }
            }

            return matchResultViewModel;

        }
    }

}
