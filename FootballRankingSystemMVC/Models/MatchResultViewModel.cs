using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC.Models
{
    public class MatchResultViewModel
    {
        public string NameTeamX { get; set; }
        public string NameTeamY { get; set; }
        public List<TeamViewModel> Teams{ get; set; }

    }
}
