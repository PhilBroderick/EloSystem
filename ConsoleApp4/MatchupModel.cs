using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    public class Matchup
    {
        public List<TeamModel> enteredTeams { get; set; }
        public int User1Score { get; set; }
        public int User2Score { get; set; }

        public TeamModel winnerTeam { get; set; }
    }
}
