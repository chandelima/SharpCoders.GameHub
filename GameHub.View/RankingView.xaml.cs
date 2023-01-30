using GameHub.Model;
using GameHub.Service;
using System.Collections.Generic;
using System.Windows;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RankingView : Window
    {
        UserService userService = new UserService();
        
        public RankingView()
        {
            InitializeComponent();
            PopulateDg();
        }

        private void PopulateDg()
        {
            List<RankingPlayer> playersList = userService.GetPlayers();
            dgvRanking.ItemsSource = playersList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
