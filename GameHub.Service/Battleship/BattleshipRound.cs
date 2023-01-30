using GameHub.Model;
using GameHub.Model.Battleship;
using GameHub.Model.Battleship.Enum;
using GameHub.Model.Enum;

namespace GameHub.Service.Battleship;

public class BattleshipRound : Round
{
    private const short BOARD_SIZE = 8;
    public enumBattleshipShip[,] Grid { get; private set; } = new enumBattleshipShip[BOARD_SIZE, BOARD_SIZE];
    public BattleshipPlayer Player1 { get; }
    public BattleshipPlayer Player2 { get; }


    public BattleshipRound(Player player1, Player player2)
    {
        Player1 = CreateBattleShipPlayer(player1, EnumPlayer.Player1);
        Player2 = CreateBattleShipPlayer(player2, EnumPlayer.Player2);

        GenerateGrid();
    }

    private BattleshipPlayer CreateBattleShipPlayer(Player player, EnumPlayer playerNumber)
    {
        BattleshipPlayer battleShipPlayer = new BattleshipPlayer(
            player.Name, player.Username, player.Password, playerNumber);

        return battleShipPlayer;
    }

    private void GenerateGrid()
    {
        Grid[1, 4] = enumBattleshipShip.BigFrontH;
        Grid[1, 5] = enumBattleshipShip.BigMiddleH;
        Grid[1, 6] = enumBattleshipShip.BigRearH;
        Grid[2, 1] = enumBattleshipShip.BigFrontV;
        Grid[3, 1] = enumBattleshipShip.BigMiddleV;
        Grid[4, 1] = enumBattleshipShip.BigRearV;
        Grid[3, 4] = enumBattleshipShip.Small;
        Grid[4, 6] = enumBattleshipShip.Small;
        Grid[6, 4] = enumBattleshipShip.Small;
    }

    public bool CheckEndGame()
    {
        bool result = false;

        int sumStrikes = Player1.Strikes + Player2.Strikes;

        if(sumStrikes >= 9)
        {
            if (Player1.Strikes > Player2.Strikes)
                WinnerPlayer = Player1;
            else
                WinnerPlayer = Player2;

            result = true;
        }

        return result;
    }
}
