using GameHub.Model;
using GameHub.Model.TicTacToe;
using GameHub.Model.TicTacToe.Enum;

namespace GameHub.Service.TicTacToe
{
    public class TicTacToeRound : Round
    {

        private enumTicTacToePlayer[,] grid = new enumTicTacToePlayer[3, 3];
        private int Moves = 0;
   
        public TicTacToePlayer Player1 { get; private set; }
        public TicTacToePlayer Player2 { get; private set; }
        public enumTicTacToePlayer CurrentRoundSymbol { get; private set; } = enumTicTacToePlayer.O;
        public enumTicTacToeRoundStatus WinStatus { get; private set; }



        public TicTacToeRound(Player player1, Player player2)
        {
            Player1 = CreateBattleShipPlayer(player1, enumTicTacToePlayer.O);
            Player2 = CreateBattleShipPlayer(player2, enumTicTacToePlayer.X);

        }

        private TicTacToePlayer CreateBattleShipPlayer(Player player, enumTicTacToePlayer symbol)
        {
            TicTacToePlayer ticTacToePlayer = new TicTacToePlayer(
                player.Name, player.Username, player.Password, symbol);

            return ticTacToePlayer;
        }

        public TicTacToeMoveResult Move(int column, int row)
        {
            grid[column, row] = CurrentRoundSymbol;
            Moves++;
            CurrentRoundSymbol = NextRoundSymbol();

            TicTacToeMoveResult result = new TicTacToeMoveResult(CurrentRoundSymbol, CheckEndGame());
            return result;
        }

        private enumTicTacToePlayer NextRoundSymbol()
        {
            if (CurrentRoundSymbol == enumTicTacToePlayer.O)
                return enumTicTacToePlayer.X;
            else
                return enumTicTacToePlayer.O;
        }

        private bool CheckEndGame()
        {
            bool result = false;

            if (
                CheckHorizontalWin(0, enumTicTacToePlayer.O) ||
                CheckHorizontalWin(1, enumTicTacToePlayer.O) ||
                CheckHorizontalWin(2, enumTicTacToePlayer.O) ||
                CheckVerticalWin(0, enumTicTacToePlayer.O) ||
                CheckVerticalWin(1, enumTicTacToePlayer.O) ||
                CheckVerticalWin(2, enumTicTacToePlayer.O) ||
                CheckTransversalWin(0, enumTicTacToePlayer.O) ||
                CheckTransversalWin(1, enumTicTacToePlayer.O) ||
                CheckHorizontalWin(0, enumTicTacToePlayer.X) ||
                CheckHorizontalWin(1, enumTicTacToePlayer.X) ||
                CheckHorizontalWin(2, enumTicTacToePlayer.X) ||
                CheckVerticalWin(0, enumTicTacToePlayer.X) ||
                CheckVerticalWin(1, enumTicTacToePlayer.X) ||
                CheckVerticalWin(2, enumTicTacToePlayer.X) ||
                CheckTransversalWin(0, enumTicTacToePlayer.X) ||
                CheckTransversalWin(1, enumTicTacToePlayer.X) ||
                CheckDraw()
                )
                result = true;

            return result;
        }

        private bool CheckHorizontalWin(int rowIndex, enumTicTacToePlayer symbol)
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
                        WinStatus = enumTicTacToeRoundStatus.Horizontal0;
                        break;
                    case 1:
                        WinStatus = enumTicTacToeRoundStatus.Horizontal1;
                        break;
                    case 2:
                        WinStatus = enumTicTacToeRoundStatus.Horizontal2;
                        break;
                }

                return true;
            }

            return false;
        }

        private bool CheckVerticalWin(int columnIndex, enumTicTacToePlayer symbol)
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
                        WinStatus = enumTicTacToeRoundStatus.Vertical0;
                        break;
                    case 1:
                        WinStatus = enumTicTacToeRoundStatus.Vertical1;
                        break;
                    case 2:
                        WinStatus = enumTicTacToeRoundStatus.Vertical2;
                        break;
                }

                return true;
            }

            return false;
        }

        private bool CheckTransversalWin(int diagonal, enumTicTacToePlayer symbol)
        {
            // diagonal = 0 --> Main Diagonal
            // diagonal = 1 --> Secondary Diagonal
            // TODO: Convert int parameter to enum, and remove the comments above...

            int sumMoves = 0;

            if (diagonal == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        if (i == j && grid[i, j] == symbol)
                            sumMoves += 1;
                }
            }
            else
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

                switch (diagonal)
                {
                    case 0:
                        WinStatus = enumTicTacToeRoundStatus.Transversal0;
                        break;
                    case 1:
                        WinStatus = enumTicTacToeRoundStatus.Transversal1;
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
                WinStatus = enumTicTacToeRoundStatus.Draw;
                return true;
            }

            return false;
        }

        private TicTacToePlayer GetWinnerPlayer(enumTicTacToePlayer symbol)
        {
            if (Player1.EnumPlayer == symbol)
                return Player1;
            else
                return Player2;
        }
    }
}
