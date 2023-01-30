using GameHub.Model;
using GameHub.Model.Enum;
using GameHub.Model.TicTacToe.Enum;
using GameHub.Service;
using GameHub.Service.Battleship;
using GameHub.Service.TicTacToe;
using System.Windows;
using System.Windows.Controls;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        NewGameView NgvForm;
        EnumPlayer PlayerOrder;


        public LoginView(NewGameView ngvForm, EnumPlayer playerOrder)
        {
            InitializeComponent();
            NgvForm = ngvForm;
            PlayerOrder = playerOrder;
            txtUser.Focus();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();

            Player? player = userService.DoLogin(txtUser.Text, txtPassword.Password);

            if (player == null)
            {
                MessageBox.Show("Dados fornecidos incorretos. Tente novamente!");
                txtUser.Clear();
                txtPassword.Clear();
                txtUser.Focus();
                return;
            }

            if (PlayerOrder == EnumPlayer.Player1)
                NgvForm.Player1 = player;
            else
                NgvForm.Player2 = player;

            this.Close();
        }

        private void CheckInputsFilled(object sender, TextChangedEventArgs e)
        {
            if (txtUser.Text.Length > 0 && txtPassword.Password.Length > 0)
                btnLogin.IsEnabled = true;
        }

        private void CheckInputsFilled(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length > 0 && txtPassword.Password.Length > 0)
                btnLogin.IsEnabled = true;
        }
    }
}
