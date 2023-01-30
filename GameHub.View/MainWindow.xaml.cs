using System.Windows;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            NewGameView newGame = new NewGameView();
            newGame.ShowDialog();
            
            this.Show();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            RegisterUserView registerUserView = new RegisterUserView();
            registerUserView.ShowDialog();

            this.Show();
        }

        private void btnRanking_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
            RankingView rankingView = new RankingView();
            rankingView.ShowDialog();

            this.Show();
        }
    }
}
