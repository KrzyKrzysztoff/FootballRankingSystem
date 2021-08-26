using FootballRankingSystemMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

    }

}
