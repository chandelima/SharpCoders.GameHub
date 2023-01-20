using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Service;

namespace TicTacToe.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameGUI : Window
    {
        Round round;
        List<Button> buttons;
        enumPlayer nextPlayer;
        List<Player> playerList = new List<Player>();
        List<Line> linesList = new List<Line>();

        public GameGUI(Round round)
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

            playerList.Add(round.Player1);
            playerList.Add(round.Player2);
            SetPlayer(round.CurrentRoundSymbol);
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Background != Brushes.Transparent)
                return;

            SetButtonImage(btn);

            string[] movePositionString = btn.Tag.ToString().Split(',');
            int[] movePosition = movePositionString
                .Select(int.Parse).ToArray();

            MoveResult moveResult = round.Move(movePosition[0], movePosition[1]);
            if (moveResult.EndRound == false)
            {
                SetPlayer(moveResult.NextPlayer);
                return;
            }

            else if (round.WinStatus == enumRoundStatus.Draw)
                MessageBox.Show($"Deu velha! :/\n\nFim da partida sem vencedor.");
            else
            {
                ShowWinLine(round.WinStatus);
                MessageBox.Show($"Fim da partida.\nVencedor: {round.WinnerPlayer.Name}");
            }

            DisableButtons();
        }

        private void SetPlayer(enumPlayer nextPlayer)
        {
            this.nextPlayer = nextPlayer;

            Player player = playerList.FirstOrDefault(p => p.EnumPlayer == nextPlayer);
            lblPlayerName.Content = player.Name;
        }

        private void SetButtonImage(Button btn)
        {
            string imageAsset = round.CurrentRoundSymbol == enumPlayer.O ?
                "GUI/Assets/btnO.png" : "GUI/Assets/btnX.png";

            Uri resource = new Uri(imageAsset, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
            BitmapFrame bmpFrameBtnO = BitmapFrame.Create(streamInfo.Stream);
            ImageBrush brushBtnO = new ImageBrush();
            brushBtnO.ImageSource = bmpFrameBtnO;

            btn.Background = brushBtnO;
        }

        private void NewRound(object sender, RoutedEventArgs e)
        {
            Round newRound = new Round(
                round.Player1.Name, 
                round.Player2.Name, 
                enumPlayer.O);

            round = newRound;
            
            foreach (var btn in buttons)
            {
                btn.IsEnabled = true;
                btn.Background = Brushes.Transparent;
            }

            HideWinLines();
        }

        private void ShowWinLine(enumRoundStatus winType)
        {
            switch (winType)
            {
                case enumRoundStatus.Horizontal0:
                    winLineH0.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Horizontal1:
                    winLineH1.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Horizontal2:
                    winLineH2.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Vertical0:
                    winLineV0.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Vertical1:
                    winLineV1.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Vertical2:
                    winLineV2.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Transversal0:
                    winLineT0.Visibility = Visibility.Visible;
                    break;
                case enumRoundStatus.Transversal1:
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
