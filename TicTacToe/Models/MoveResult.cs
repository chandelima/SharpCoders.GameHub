using TicTacToe.Models.Enums;

namespace TicTacToe.Models
{
    public class MoveResult
    {
        public enumPlayer NextPlayer { get; set; }
        public bool EndRound { get; set; }

        public MoveResult(enumPlayer nextPlayer, bool endRound)
        {
            NextPlayer = nextPlayer;
            EndRound = endRound;
        }
    }
}
