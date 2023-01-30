using GameHub.Model;
using GameHub.Model.Enum;
using GameHub.Model.TicTacToe.Enum;
using GameHub.Service;
using GameHub.Service.Battleship;
using GameHub.Service.TicTacToe;
using System.Numerics;
using System.Windows;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterUserView : Window
    {
        
        public RegisterUserView()
        {
            InitializeComponent();
            txtFullName.Focus();
        }

        private void CheckAllFieldsAreFilled()
        {
            if(txtFullName.Text.Length > 0 && 
               txtUser.Text.Length > 0 &&
               txtPassword.Password.Length > 0 &&
               txtPasswordConfirm.Password.Length > 0)
            {
                btnRegister.IsEnabled = true;
            } else
            {
                btnRegister.IsEnabled = false;
            }
        }

        private void txt_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CheckAllFieldsAreFilled();
        }

        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            CheckAllFieldsAreFilled();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password != txtPasswordConfirm.Password)
            {
                MessageBox.Show("As senhas informadas são diferentes. Tente novamente!");
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Password.Length < 6)
            {
                MessageBox.Show("A senha deve ter pelo 6 menos caractéres. Tente novamente!");
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtPassword.Focus();
                return;
            }

            RankingPlayer playerToCreate = new RankingPlayer(
                txtFullName.Text,
                txtUser.Text,
                txtPassword.Password);

            UserService userService = new UserService();
            if (userService.Create(playerToCreate))
            {
                MessageBox.Show("Usuário cadastrado com sucesso.");
                this.Close();
            } else
            {
                MessageBox.Show("O nome de usuário fornecido já existe. Tente novamente!");
                txtFullName.Clear();
                txtUser.Clear();
                txtPassword.Clear();
                txtPasswordConfirm.Clear();
                txtFullName.Focus();
            };
        }
    }
}
