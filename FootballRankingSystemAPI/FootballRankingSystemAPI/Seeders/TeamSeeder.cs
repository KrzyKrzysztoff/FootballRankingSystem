using FootballRankingSystemAPI.Entities;
using FootballRankingSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Seeders
{
    public class TeamSeeder
    {
        private readonly RankingDbContext rankingDbContext;

        public TeamSeeder(RankingDbContext rankingDbContext)
        {
            this.rankingDbContext = rankingDbContext;
        }

        public void Seed()
        {

            if (rankingDbContext.Database.CanConnect())
            {
                var pandingMigration = rankingDbContext.Database.GetPendingMigrations();

                if (pandingMigration != null && pandingMigration.Any())
                {
                    rankingDbContext.Database.Migrate();
                }

                if (!rankingDbContext.Confederation.Any())
                {
                    var confederations = GetConfederations();

                    rankingDbContext.AddRange(confederations);

                    rankingDbContext.SaveChanges();
                }

                if (!rankingDbContext.Team.Any())
                {
                    var teams = GetTeams();

                    rankingDbContext.Team.AddRange(teams);

                    rankingDbContext.SaveChanges();
                }

                if (!rankingDbContext.MatchStatus.Any())
                {
                    var matchStatuses = GetMatchStatuses();

                    rankingDbContext.MatchStatus.AddRange(matchStatuses);

                    rankingDbContext.SaveChanges();
                }
               
            }


        }
        public List<MatchStatus> GetMatchStatuses()
        {
            var matchStatuses = new List<MatchStatus>()
            {
                new MatchStatus{Name = "FriendlyMatch", Multiplier = 1},
                new MatchStatus{Name = "FifaWorld_ContinentalCup", Multiplier = 2},
                new MatchStatus{Name = "ContinentalCupFinal", Multiplier = 3},
                new MatchStatus{Name = "FifaWorldFinal", Multiplier = 4},
            };

            return matchStatuses;
        }
        public List<Confederation> GetConfederations()
        {
            var confederations = new List<Confederation>()
            {
                new Confederation{Name = ConfederationEnum.CONMEBOL, Weight = 1},
                new Confederation{Name = ConfederationEnum.UEFA, Weight = 0.99f},
                new Confederation{Name = ConfederationEnum.AFC, Weight = 0.85f},
                new Confederation{Name = ConfederationEnum.CAF, Weight = 0.85f},
                new Confederation{Name = ConfederationEnum.OFC, Weight = 0.85f},
                new Confederation{Name = ConfederationEnum.CONCACAF, Weight = 0.85f},
            };

            return confederations;

        }
        public List<Team> GetTeams()
        {

            var teams = new List<Team>()
            {
                new Team{Name = "Belgium", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1822, RankingPlace = 1},
                new Team{Name = "Brazil", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1798, RankingPlace = 2},
                new Team{Name = "France", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1762, RankingPlace = 3},
                new Team{Name = "England", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1753, RankingPlace = 4},
                new Team{Name = "Italy", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1745,RankingPlace = 5},
                new Team{Name = "Argentina", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1714,RankingPlace = 6},
                new Team{Name = "Spain", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1680, RankingPlace = 7},
                new Team{Name = "Portugal", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1662, RankingPlace = 8},
                new Team{Name = "Mexico", Confederation = FindConfederation(ConfederationEnum.CONCACAF), Points = 1658, RankingPlace = 9},
                new Team{Name = "USA", Confederation = FindConfederation(ConfederationEnum.CONCACAF), Points = 1648, RankingPlace = 10},
                new Team{Name = "Denmark", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1642,RankingPlace = 11},
                new Team{Name = "Netherlands", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1637, RankingPlace = 12},
                new Team{Name = "Uruguay", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1635,RankingPlace = 13},
                new Team{Name = "Switzerland", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1622,RankingPlace = 14},
                new Team{Name = "Colombia", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1618, RankingPlace = 15},
                new Team{Name = "Germany", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1613, RankingPlace = 16},
                new Team{Name = "Sweden", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1607, RankingPlace = 17},
                new Team{Name = "Croatia", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1594, RankingPlace = 18},
                new Team{Name = "Wales", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1567, RankingPlace = 19},
                new Team{Name = "Chile", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1558, RankingPlace = 20},
                new Team{Name = "Senegal", Confederation = FindConfederation(ConfederationEnum.CAF), Points = 1545, RankingPlace = 21},
                new Team{Name = "Peru", Confederation = FindConfederation(ConfederationEnum.CONMEBOL), Points = 1543, RankingPlace = 22},
                new Team{Name = "Austria", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1535, RankingPlace = 23},
                new Team{Name = "Japan", Confederation = FindConfederation(ConfederationEnum.AFC), Points = 1529, RankingPlace = 24},
                new Team{Name = "Ukraine", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1523, RankingPlace = 25},
                new Team{Name = "Iran", Confederation = FindConfederation(ConfederationEnum.AFC), Points = 1522, RankingPlace = 26},
                new Team{Name = "Poland", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1516, RankingPlace = 27},
                new Team{Name = "Tunisia", Confederation = FindConfederation(ConfederationEnum.CAF), Points = 1515, RankingPlace = 28},
                new Team{Name = "Serbia", Confederation = FindConfederation(ConfederationEnum.CAF), Points = 1507, RankingPlace = 29},
                new Team{Name = "Algeria", Confederation = FindConfederation(ConfederationEnum.UEFA), Points = 1499, RankingPlace = 30}

            };

            return teams;
        }
        public Confederation FindConfederation(ConfederationEnum confederationEnum)
        {
            return rankingDbContext.Confederation.FirstOrDefault(x => x.Name == confederationEnum);
        }
    }
}



