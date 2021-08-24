using FootballRankingSystemAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Entities
{
    public class Confederation
    {
        public int Id { get; set; }
        public ConfederationEnum Name{ get; set; }
        public double Weight { get; set; }
    }
}
