using GameHub.Model;
using GameHub.Model.TicTacToe;
using GameHub.Model.TicTacToe.Enum;
using GameHub.Service.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace GameHub.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TicTacToeView : Window
    {
        TicTacToeRound round;
        enumTicTacToePlayer nextPlayer;
        List<Button> buttons;
        Player Player1;
        Player Player2;
        List<Line> linesList;

        public TicTacToeView(TicTacToeRound round)
        {
            InitializeComponent();
            this.round = round;

            buttons = new List<Button>()
            {
                btn00, btn01, btn02,
                btn10, btn11, btn12,
                btn20, btn21, btn22,
            };

            linesList = new List<Line>()
            {
                winLineH0, winLineH1, winLineH2,
                winLineV0, winLineV1, winLineV2,
                winLineT0, winLineT1
            };

            Player1 = round.Player1;
            Player2 = round.Player2;
            
            SetPlayer(round.CurrentRoundSymbol);
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Background != Brushes.Transparent)
                return;

            SetButtonImage(btn);

            string[] movePositionString = btn.Tag.ToString()!.Split(',');
            int[] movePosition = movePositionString.Select(int.Parse).ToArray();

            TicTacToeMoveResult moveResult = round.Move(movePosition[0], movePosition[1]);
            if (moveResult.EndRound == false)
            {
                SetPlayer(moveResult.NextPlayer);
                return;
            }
            else if (round.WinStatus == enumTicTacToeRoundStatus.Draw)
            {
                MessageBox.Show($"Deu velha! :/\n\nFim da partida sem vencedor.");
            }
            else
            {
                ShowWinLine(round.WinStatus);
                MessageBox.Show($"Fim da partida.\nVencedor: {round.WinnerPlayer!.Name}");
            }

            DisableButtons();
        }

        private void SetPlayer(enumTicTacToePlayer nextPlayer)
        {
            this.nextPlayer = nextPlayer;

            if(nextPlayer == enumTicTacToePlayer.O)
                lblPlayerName.Content = Player1.Name;
            else
                lblPlayerName.Content = Player2.Name;
        }

        private void SetButtonImage(Button btn)
        {
            string imageAsset;

            if (round.CurrentRoundSymbol == enumTicTacToePlayer.O)
                imageAsset = "Assets/TicTacToe/btnO.png";
            else
                imageAsset = "Assets/TicTacToe/btnX.png";

            Uri resource = new Uri(imageAsset, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
            BitmapFrame bmpFrameBtnO = BitmapFrame.Create(streamInfo.Stream);
            ImageBrush brushBtnO = new ImageBrush();
            brushBtnO.ImageSource = bmpFrameBtnO;

            btn.Background = brushBtnO;
        }

        private void NewRound(object sender, RoutedEventArgs e)
        {
            TicTacToeRound newRound = new TicTacToeRound(round.Player1, round.Player2);

            round = newRound;
            
            foreach (var btn in buttons)
            {
                btn.IsEnabled = true;
                btn.Background = Brushes.Transparent;
            }

            HideWinLines();
        }

        private void ShowWinLine(enumTicTacToeRoundStatus winType)
        {
            switch (winType)
            {
                case enumTicTacToeRoundStatus.Horizontal0:
                    winLineH0.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Horizontal1:
                    winLineH1.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Horizontal2:
                    winLineH2.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Vertical0:
                    winLineV0.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Vertical1:
                    winLineV1.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Vertical2:
                    winLineV2.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Transversal0:
                    winLineT0.Visibility = Visibility.Visible;
                    break;
                case enumTicTacToeRoundStatus.Transversal1:
                    winLineT1.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void HideWinLines()
        {
            foreach (var line in linesList)
                line.Visibility = Visibility.Hidden;
        }

        private void DisableButtons()
        {
            foreach (var btn in buttons)
                btn.IsEnabled = false;
        }
    }
}
