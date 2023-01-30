using GameHub.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Model.Battleship
{
    public class BattleshipPlayer : Player
    {
        public EnumPlayer PlayerNumber;
        public short Strikes { get; private set; } = 0;

        public BattleshipPlayer(string name, string username, string password, EnumPlayer playerNumber)
            : base(name, username, password)
        {
            PlayerNumber = playerNumber;
        }

        public void SetStrike() => Strikes++;
    }
}
