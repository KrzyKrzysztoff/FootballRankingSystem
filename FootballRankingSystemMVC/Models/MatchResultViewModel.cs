using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC.Models
{
    public class MatchResultViewModel
    {
        public DateTime Date { get; set; }
        public int GoalsScoredByWinTeam { get; set; }
        public int GoalsScoredByLoseTeam { get; set; }
        public bool IsDraw { get; set; }
        public string TeamWinOrDrawName { get; set; }
        public string TeamLostOrDrawName { get; set; }
        public double TeamWinOrDrawPointsScored { get; set; }
        public double TeamLostOrDrawPointsScored { get; set; }

    }
}
