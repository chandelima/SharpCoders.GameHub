using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models
{
    public class Player
    {
        public string Name { get; private set; }
        public string Score { get; private set; }
        public enumPlayer EnumPlayer { get; private set; }

        public Player(string name, enumPlayer enumPlayer)
        {
            Name = name;
            EnumPlayer = enumPlayer;
        }

        public void ChangePlayer()
        {
            EnumPlayer = EnumPlayer == enumPlayer.O ?
                enumPlayer.X : enumPlayer.O;
        }

        public void SetSymbol(enumPlayer symbol) =>
            EnumPlayer = symbol;
    }
}
