using GameHub.Model;
using GameHub.Model.Enum;

namespace GameHub.Service
{
    public class Round
    {

        private enumPlayer[,] grid = new enumPlayer[3, 3];
        private List<Player> players = new List<Player>();


        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public enumPlayer CurrentRoundSymbol { get; private set; }
        public Player WinnerPlayer { get; private set; }
        public enumRoundStatus WinStatus { get; private set; }
        public int Moves { get; private set; } = 0;


        public Round(string player1, string player2, enumPlayer firstRoundSymbol)
        {
            CurrentRoundSymbol = firstRoundSymbol;

            Player1 = new Player(player1, firstRoundSymbol);
            Player2 = new Player(player2, NextRoundSymbol());

            players.Add(Player1);
            players.Add(Player2);
        }

        public MoveResult Move(int column, int row)
        {
            grid[column, row] = CurrentRoundSymbol;
            Moves++;
            CurrentRoundSymbol = NextRoundSymbol();

            MoveResult result = new MoveResult(CurrentRoundSymbol, CheckEndGame());
            return result;
        }

        private enumPlayer NextRoundSymbol()
        {
            return CurrentRoundSymbol == enumPlayer.O ?
                enumPlayer.X : enumPlayer.O;
        }

        private bool CheckEndGame()
        {
            bool result = false;

            if (
                CheckHorizontalWin(0, enumPlayer.O) ||
                CheckHorizontalWin(1, enumPlayer.O) ||
                CheckHorizontalWin(2, enumPlayer.O) ||
                CheckVerticalWin(0, enumPlayer.O) ||
                CheckVerticalWin(1, enumPlayer.O) ||
                CheckVerticalWin(2, enumPlayer.O) ||
                CheckTransversalWin(0, enumPlayer.O) ||
                CheckTransversalWin(1, enumPlayer.O) ||
                CheckHorizontalWin(0, enumPlayer.X) ||
                CheckHorizontalWin(1, enumPlayer.X) ||
                CheckHorizontalWin(2, enumPlayer.X) ||
                CheckVerticalWin(0, enumPlayer.X) ||
                CheckVerticalWin(1, enumPlayer.X) ||
                CheckVerticalWin(2, enumPlayer.X) ||
                CheckTransversalWin(0, enumPlayer.X) ||
                CheckTransversalWin(1, enumPlayer.X) ||
                CheckDraw()
                )
                result = true;

            return result;
        }

        private bool CheckHorizontalWin(int rowIndex, enumPlayer symbol)
        {
            int sumMoves = 0;

            for (int i = 0; i < 3; i++)
            {
                if (grid[rowIndex, i] == symbol)
                    sumMoves += 1;
            }

            if (sumMoves == 3)
            {
                WinnerPlayer = GetWinnerPlayer(symbol);

                switch (rowIndex)
                {
                    case 0:
                        WinStatus = enumRoundStatus.Horizontal0;
                        break;
                    case 1:
                        WinStatus = enumRoundStatus.Horizontal1;
                        break;
                    case 2:
                        WinStatus = enumRoundStatus.Horizontal2;
                        break;
                }

                return true;
            }

            return false;
        }

        private bool CheckVerticalWin(int columnIndex, enumPlayer symbol)
        {
            int sumMoves = 0;

            for (int i = 0; i < 3; i++)
            {
                if (grid[i, columnIndex] == symbol)
                    sumMoves += 1;
            }

            if (sumMoves == 3)
            {
                WinnerPlayer = GetWinnerPlayer(symbol);

                switch (columnIndex)
                {
                    case 0:
                        WinStatus = enumRoundStatus.Vertical0;
                        break;
                    case 1:
                        WinStatus = enumRoundStatus.Vertical1;
                        break;
                    case 2:
                        WinStatus = enumRoundStatus.Vertical2;
                        break;
                }

                return true;
            }

            return false;
        }

        private bool CheckTransversalWin(int diagonal, enumPlayer symbol)
        {
            // diagonal = 0 --> Main Diagonal
            // diagonal = 1 --> Secondary Diagonal

            int sumMoves = 0;

            if (diagonal == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        if (i == j && grid[i, j] == symbol)
                            sumMoves += 1;
                }
            } else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        if (i + j == 3 - 1 && grid[i, j] == symbol)
                            sumMoves += 1;
                }
            }

            if (sumMoves == 3)
            {
                WinnerPlayer = GetWinnerPlayer(symbol);

                switch(diagonal)
                {
                    case 0:
                        WinStatus = enumRoundStatus.Transversal0;
                        break;
                    case 1:
                        WinStatus = enumRoundStatus.Transversal1;
                        break;
                }

                return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            if (Moves >= 9)
            {
                WinStatus = enumRoundStatus.Draw;
                return true;
            }

            return false;
        }

        private Player GetWinnerPlayer(enumPlayer symbol)
        {
            return players
                    .FirstOrDefault(p => p.EnumPlayer == symbol);
        }
    }
}
