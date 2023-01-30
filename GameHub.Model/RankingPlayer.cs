using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Model
{
    public class RankingPlayer : Player
    {
        public int TicTacToeWins { get; set; } = 0;
        public int BattleshipWins { get; set; } = 0;
        public int TotalWins { get => TicTacToeWins + BattleshipWins; }

        public RankingPlayer(string name, string username, string password)
            : base(name, username, password) { }
    }
}
