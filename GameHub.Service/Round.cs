using GameHub.Model;
using GameHub.Model.TicTacToe;

namespace GameHub.Service;

public abstract class Round
{
    public Player? winnerPlayer;
    
    public Player? WinnerPlayer { 
        get
        {
            return winnerPlayer;
        }
        set
        {
            winnerPlayer = value;
            
            UserService userService = new UserService();

            if(winnerPlayer is TicTacToePlayer)
                userService.SetTicTacToeWin(winnerPlayer);
            else
                userService.SetBattleshipWin(winnerPlayer!);
        }
    }
}
