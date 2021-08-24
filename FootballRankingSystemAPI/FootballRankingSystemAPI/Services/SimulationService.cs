using FootballRankingSystemAPI.Entities;
using FootballRankingSystemAPI.Exceptions;
using FootballRankingSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballRankingSystemAPI.Services
{
    public class SimulationService : ISimulationService
    {
        private readonly RankingDbContext rankingDbContext;

        public SimulationService(RankingDbContext rankingDbContext)
        {
            this.rankingDbContext = rankingDbContext;
        }
        public MatchResult Simulation(SimulationDto simulationDto)
        {
            var matchStatus = rankingDbContext.MatchStatus.FirstOrDefault(x => x.Name == simulationDto.MatchStatusName);

            if (matchStatus == null)
            {
                throw new NotFoundException("Not founded match status");
            }

            var teamX = rankingDbContext.Team
                .Include(x => x.Confederation)
                .FirstOrDefault(x => x.Name == simulationDto.NameTeamX);

            var teamY = rankingDbContext.Team
                .Include(x => x.Confederation)
                .FirstOrDefault(x => x.Name == simulationDto.NameTeamY);

            if (teamX == null || teamY == null)
            {
                throw new NotFoundException("Not founded teams");
            }

            GetChance(teamY, teamX);

            //1.0 is a draw chance
            double maxValue = teamY.Chance + 1 + teamX.Chance;

            var random = new Random();

            var result = random.NextDouble() * (maxValue - 0) + 0;

            if (0 <= result && result <= teamY.Chance)
            {
                var matchResult = GetMatchResult(teamY, teamX, false);

                AddPoints(teamX, teamY, matchResult, false, matchStatus);

                return matchResult;
            }
            else if (result > teamY.Chance && teamY.Chance + 1 >= result)
            {
                var matchResult = GetMatchResult(teamY, teamX, true);

                AddPoints(teamX, teamY, matchResult, true, matchStatus);

                return matchResult;
            }
            else if (teamY.Chance + 1 < result && result <= maxValue)
            {
                var matchResult = GetMatchResult(teamX, teamY, false);

                AddPoints(teamY, teamX, matchResult, false, matchStatus);

                return matchResult;
            }

            return null;

        }

        private MatchResult GetMatchResult(Team teamWin, Team teamLost, bool isDraw)
        {


            int goalsScoredByWinTeam = 0;
            int goalsScoredByLoseTeam = 0;

            var rnd = new Random();

            //result for draw
            if (isDraw)
            {
                goalsScoredByWinTeam = (int)teamLost.Chance;
                goalsScoredByLoseTeam = goalsScoredByWinTeam;

                var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, true);

                ChanceReset(teamWin, teamLost);

                return result;
            }
            //result for the team that had less chance 
            if (teamWin.Chance < teamLost.Chance)
            {
                if (teamWin.Chance < 0.99)
                {
                    goalsScoredByWinTeam = 1;
                    goalsScoredByLoseTeam = 0;

                    var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, false);

                    ChanceReset(teamWin, teamLost);

                    return result;
                }
                else
                {
                    int chancesDifference = (int)teamLost.Chance - (int)teamWin.Chance;

                    if (chancesDifference <= 2)
                    {
                        chancesDifference = 2;

                        goalsScoredByWinTeam = chancesDifference;
                        goalsScoredByLoseTeam = (int)teamWin.Chance;

                        var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, false);

                        ChanceReset(teamWin, teamLost);

                        return result;
                    }
                    else
                    {
                        goalsScoredByWinTeam = chancesDifference;
                        goalsScoredByLoseTeam = (int)teamWin.Chance;

                        var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, false);

                        ChanceReset(teamWin, teamLost);

                        return result;
                    }
                }
            }
            // result for the team that had more chance
            else if (teamWin.Chance > teamLost.Chance)
            {
   
                goalsScoredByWinTeam = (int)teamWin.Chance;
                goalsScoredByLoseTeam = (int)teamLost.Chance;

                var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, false);

                ChanceReset(teamWin, teamLost);

                return result;
            }
            // result for the team that had same chance
            else if (teamWin.Chance == teamLost.Chance)
            {
                goalsScoredByWinTeam = (int)teamWin.Chance + 1;
                goalsScoredByLoseTeam = (int)teamLost.Chance;

                var result = SetMatchResult(goalsScoredByWinTeam, goalsScoredByLoseTeam, teamWin, teamLost, false);

                ChanceReset(teamWin, teamLost);

                return result;
            }
            return null;
        }

        private void ChanceReset(Team teamWinOrDraw, Team teamLostOrDraw)
        {
            teamLostOrDraw.Chance = 0;
            teamWinOrDraw.Chance = 0;
        }
        private MatchResult SetMatchResult(int goalsScoredByWinTeam, int goalsScoredByLoseTeam, Team teamWinOrDraw, Team teamLostOrDraw, bool isDraw)
        {
            if (isDraw)
            {
                MatchResult matchResultDraw = new MatchResult();

                matchResultDraw.Date = DateTime.Now;
                matchResultDraw.TeamLostOrDrawName = teamLostOrDraw.Name;
                matchResultDraw.TeamWinOrDrawName = teamWinOrDraw.Name;
                matchResultDraw.IsDraw = true;
                matchResultDraw.GoalsScoredByLoseTeam = goalsScoredByLoseTeam;
                matchResultDraw.GoalsScoredByWinTeam = goalsScoredByWinTeam;

                SetData(teamLostOrDraw, teamWinOrDraw, matchResultDraw);

                return matchResultDraw;
            }
            else
            {
                MatchResult matchResult = new MatchResult();

                matchResult.Date = DateTime.Now;
                matchResult.TeamLostOrDrawName = teamLostOrDraw.Name;
                matchResult.TeamWinOrDrawName = teamWinOrDraw.Name;
                matchResult.IsDraw = false;
                matchResult.GoalsScoredByLoseTeam = goalsScoredByLoseTeam;
                matchResult.GoalsScoredByWinTeam = goalsScoredByWinTeam;

                SetData(teamLostOrDraw, teamWinOrDraw, matchResult);
                return matchResult;
            }
        }
        private void AddPoints(Team teamLostOrDraw, Team teamWinOrDraw, MatchResult matchResult, bool isDraw, MatchStatus matchStatus)
        {
            double oppositionStrengthForWin = (200 / teamLostOrDraw.RankingPlace) / 100;
            int winMatchResultMultiplier = 3;

            if (oppositionStrengthForWin < 0.5)
            {
                oppositionStrengthForWin = 0.5;
            }

            if (isDraw)
            {
                int drawMatchResultMultiplier = 1;

                double oppositionStrengthForLost = (200 / teamWinOrDraw.RankingPlace) / 100;

                if (oppositionStrengthForLost < 0.5)
                {
                    oppositionStrengthForLost = 0.5;
                }

                double winnerPointsScored = matchStatus.Multiplier * teamLostOrDraw.Confederation.Weight * oppositionStrengthForWin * drawMatchResultMultiplier;
                double loserPointsScored = matchStatus.Multiplier * teamWinOrDraw.Confederation.Weight * oppositionStrengthForLost * drawMatchResultMultiplier;

                teamWinOrDraw.Points += winnerPointsScored;
                teamLostOrDraw.Points += loserPointsScored;

                matchResult.TeamLostOrDrawPointsScored = loserPointsScored;
                matchResult.TeamWinOrDrawPointsScored = winnerPointsScored;

            }
            else
            {
                double winnerPointsScored = matchStatus.Multiplier * teamLostOrDraw.Confederation.Weight * oppositionStrengthForWin * winMatchResultMultiplier; ;

                teamWinOrDraw.Points += winnerPointsScored;

                matchResult.TeamLostOrDrawPointsScored = 0;
                matchResult.TeamWinOrDrawPointsScored = winnerPointsScored;
            }

            rankingDbContext.SaveChanges();
        }
        private void SetData(Team teamLostOrDraw, Team teamWinOrDraw, MatchResult matchResult)
        {
            teamLostOrDraw.MatchResult.Add(matchResult);
            teamWinOrDraw.MatchResult.Add(matchResult);
            rankingDbContext.MatchResult.Add(matchResult);

            rankingDbContext.SaveChanges();
        }
        private void GetChance(Team teamY, Team teamX)
        {
            SetLucky(teamY, teamX);

            //Add  parametrs to chance like: ConfederationWeight, rankingPlace
            teamX.Chance += teamX.Confederation.Weight - (teamX.RankingPlace / 10);
            teamY.Chance += teamY.Confederation.Weight - (teamY.RankingPlace / 10);


            CheckChance(teamY, teamX);
        }
        private void SetLucky(Team teamY, Team teamX)
        {
            int randomLucky = 0;
            var rnd = new Random();


            //setting of luck for teams where there is a big difference in the table space
            if (teamY.RankingPlace >= teamX.RankingPlace + 10)
            {
                teamY.Chance = 5;
            }
            //luck setting for similar teams
            else
            {
                randomLucky = rnd.Next(0, 5);
                teamY.Chance = randomLucky;
            }

            if (teamX.RankingPlace >= teamY.RankingPlace + 10)
            {
                teamX.Chance = 5;
            }
            //luck setting for similar teams
            else
            {
                randomLucky = rnd.Next(0, 5);
                teamX.Chance = randomLucky;
            }
        }
        private void CheckChance(Team teamY, Team teamX)
        {
            if (teamY.Chance <= 0.99)
            {
                teamY.Chance = 1;
            }
            if (teamX.Chance <= 0.99)
            {
                teamX.Chance = 1;
            }
        }
    }
}
