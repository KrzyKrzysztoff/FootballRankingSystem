using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Entities
{
    public class MatchStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Multiplier { get; set; }
    }
}
