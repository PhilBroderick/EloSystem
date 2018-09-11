using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            TeamModel team1 = new TeamModel { id = 1, name = "Ulster", Wins = 2, Losses = 1, TeamRating = 1000 };

            TeamModel team2 = new TeamModel { id = 1, name = "Munster", Wins = 1, Losses = 2, TeamRating = 700 };

            List<TeamModel> teams = new List<TeamModel>();
            teams.Add(team1);
            teams.Add(team2);

            Matchup matchup = new Matchup { enteredTeams = teams, User1Score = 40, User2Score = 25, winnerTeam = team1 };

            RatingModel rm = new RatingModel(matchup);

            Console.WriteLine(team1.TeamRating);
            Console.WriteLine(team2.TeamRating);
            Console.ReadLine();

        }
    }
}
