using GameHub.Model;
using GameHub.Repository.Shared;

namespace GameHub.Repository;

public class RankingPlayerRepository
{
    public List<RankingPlayer> Players { get; private set; } = new List<RankingPlayer>();
    JsonIO json = new JsonIO("./players.json");

    public RankingPlayerRepository() => Desserialize();

    public bool Create(RankingPlayer player)
    {
        Players.Add(player);
        Serialize();

        return true;
    }

    public List<RankingPlayer> GetPlayers()
    {
        Desserialize();
        return Players;
    } 

    public bool DeletePlayer(RankingPlayer player)
    {
        bool result = Players.Remove(player);
        if (result != false)
            Serialize();

        return result;
    }

    public bool UpdatePlayer(RankingPlayer changedPlayer)
    {
        RankingPlayer? repositoryPlayer = Players
            .FirstOrDefault(p => p.Username == changedPlayer.Username);

        if (repositoryPlayer == null)
            return false;

        repositoryPlayer = new RankingPlayer(
            changedPlayer.Name,
            changedPlayer.Username,
            changedPlayer.Password)
        {
            TicTacToeWins = changedPlayer.TicTacToeWins,
            BattleshipWins = changedPlayer.BattleshipWins
        };

        Serialize();

        return true;
    }

    private bool Serialize() => json.Serialize(Players);

    private void Desserialize()
    {
        Players = json.Desserialize<List<RankingPlayer>>();
    }
}
