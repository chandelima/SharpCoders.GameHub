using GameHub.Model.Enum;

namespace GameHub.Model
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
