using GameHub.Model.TicTacToe.Enum;

namespace GameHub.Model.TicTacToe
{
    public class TicTacToeMoveResult
    {
        public enumTicTacToePlayer NextPlayer { get; set; }
        public bool EndRound { get; set; }

        public TicTacToeMoveResult(enumTicTacToePlayer nextPlayer, bool endRound)
        {
            NextPlayer = nextPlayer;
            EndRound = endRound;
        }
    }
}
