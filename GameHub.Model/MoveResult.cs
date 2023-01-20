using GameHub.Model.Enum;

namespace GameHub.Model
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
