using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Entities
{
    public class RankingDbContext : DbContext
    {
        private const string connectionString = "Data Source=127.0.0.1;Initial Catalog=RankingDb;User ID=sa;Password=Wsh123!@#";
        public DbSet<Confederation> Confederation { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<MatchResult> MatchResult { get; set; }
        public DbSet<MatchStatus> MatchStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}
