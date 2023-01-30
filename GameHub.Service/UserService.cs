using GameHub.Model;
using GameHub.Repository;

namespace GameHub.Service
{
    public class UserService
    {
        RankingPlayerRepository repository = new RankingPlayerRepository();
        
        public bool Create(RankingPlayer player)
        {
            if (CheckIfUserExists(player.Username))
                return false;
            
            return repository.Create(player);
        }

        public List<RankingPlayer> GetPlayers()
        {
            return repository.Players;
        }

        public RankingPlayer? GetPlayer(string username)
        {
            RankingPlayer? user = repository.Players
                .FirstOrDefault(p => p.Username == username);

            return user;
        }

        public Player? DoLogin(string username, string password)
        {
            RankingPlayer? user = repository.Players
                .FirstOrDefault(p => p.Username == username && p.Password == password);

            return user;
        }

        public bool CheckIfUserExists(string username)
        {
            RankingPlayer user = repository.Players
               .FirstOrDefault(p => p.Username == username);

            if (user == null)
                return false;

            return true;
        }

        public void SetTicTacToeWin(Player player)
        {
            RankingPlayer user = repository.Players
               .FirstOrDefault(p => p.Username == player.Username)!;
            user.TicTacToeWins++;

            repository.UpdatePlayer(user);
        }

        public void SetBattleshipWin(Player player)
        {
            RankingPlayer user = repository.Players
               .FirstOrDefault(p => p.Username == player.Username)!;
            user.BattleshipWins++;

            repository.UpdatePlayer(user);
        }
    }
}
