using FootballRankingSystemAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Points { get; set; }
        public double Chance { get; set; }
        public int RankingPlace { get; set; }


        public virtual ICollection<MatchResult> MatchResult { get; set; } = new List<MatchResult>();

        public int ConfederationId { get; set; }
        public virtual Confederation Confederation { get; set; }
    }
}
