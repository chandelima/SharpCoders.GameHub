using GameHub.Model.TicTacToe.Enum;

namespace GameHub.Model.TicTacToe
{
    public class TicTacToePlayer : Player
    {
        public enumTicTacToePlayer EnumPlayer { get; private set; }

        public TicTacToePlayer(string name, string username, string password, enumTicTacToePlayer enumPlayer)
            : base(name, username, password)
        {
            EnumPlayer = enumPlayer;
        }

        public void ChangePlayer()
        {
            if (EnumPlayer == enumTicTacToePlayer.O)
                EnumPlayer = enumTicTacToePlayer.X;
            else
                EnumPlayer = enumTicTacToePlayer.O;
        }

        public void SetSymbol(enumTicTacToePlayer symbol) => EnumPlayer = symbol;
    }
}
