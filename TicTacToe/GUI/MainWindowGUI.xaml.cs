using System.Windows;
using TicTacToe.Models.Enums;
using TicTacToe.Service;

namespace TicTacToe.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = txtPlayer1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Round round = new Round(txtPlayer1.Text, txtPlayer2.Text, enumPlayer.O);
            
            GameGUI game = new GameGUI(round);
            game.ShowDialog();
            game.Close();

            this.Show();
        }

        private void CheckPlayersAreFilled(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            btnStartRound.IsEnabled = txtPlayer1.Text != "" && txtPlayer2.Text != "" ?
                true : false;
        }
    }
}
