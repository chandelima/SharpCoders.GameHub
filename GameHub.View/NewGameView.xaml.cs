using GameHub.Model;
using GameHub.Model.Enum;
using GameHub.Model.TicTacToe.Enum;
using GameHub.Service.Battleship;
using GameHub.Service.TicTacToe;
using System.Numerics;
using System.Windows;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewGameView : Window
    {
        public Player? Player1;
        public Player? Player2;
        
        public NewGameView()
        {
            InitializeComponent();
        }

        private void btnLoginPlayer1_Click(object sender, RoutedEventArgs e)
        {
            PlayerLogin(EnumPlayer.Player1);
        }

        private void btnLoginPlayer2_Click(object sender, RoutedEventArgs e)
        {
            PlayerLogin(EnumPlayer.Player2);
        }

        private void PlayerLogin(EnumPlayer player)
        {
            this.Hide();

            LoginView login = new LoginView(this, player);
            login.ShowDialog();

            SetPlayersButtons(player);
            CheckPlayersAreLogged();

            this.ShowDialog();

        }

        
        private void SetPlayersButtons(EnumPlayer player)
        {
            if (player == EnumPlayer.Player1)
            {
                this.btnLoginPlayer1.Content = Player1!.Name;
                this.btnLoginPlayer1.IsEnabled = false;
                this.lblPlayer1Defined.Visibility = Visibility.Visible;
            }
            else
            {
                this.btnLoginPlayer2.Content = Player2!.Name;
                this.btnLoginPlayer2.IsEnabled = false;
                this.lblPlayer2Defined.Visibility = Visibility.Visible;
            }
        }
        
        private void CheckPlayersAreLogged()
        {
            if (Player1 != null && Player2 != null)
            {
                this.btnTicTacToe.Visibility = Visibility.Visible;
                this.btnTicTacToe.IsEnabled = true;
                this.btnBattleship.Visibility = Visibility.Visible;
                this.btnBattleship.IsEnabled = true;
                this.lblUnloggedWarning.Visibility = Visibility.Hidden;
            }
        }

        private void btnTicTacToe_Click(object sender, RoutedEventArgs e)
        {
            TicTacToeRound round = new TicTacToeRound(Player1!, Player2!);
            TicTacToeView ticTacToeView = new TicTacToeView(round);
            ticTacToeView.ShowDialog();
        }

        private void btnBattleship_Click(object sender, RoutedEventArgs e)
        {
            BattleshipRound round = new BattleshipRound(Player1!, Player2!);
            BattleshipView battleshipView = new BattleshipView(round);
            battleshipView.ShowDialog();
        }
    }
}
