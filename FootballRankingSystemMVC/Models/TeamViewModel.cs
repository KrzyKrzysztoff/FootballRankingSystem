using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC.Models
{
    public class TeamViewModel
    {
        public List<Team> Teams { get; set; }
        public List<MatchStatus> MatchStatus { get; set; }
        public string MatchStatusName { get; set; }
        public string TeamX { get; set; }
        public string TeamY { get; set; }
    }
}
