using GameHub.Model;
using GameHub.Model.Battleship;
using GameHub.Model.Battleship.Enum;
using GameHub.Model.Enum;
using GameHub.Model.TicTacToe;
using GameHub.Model.TicTacToe.Enum;
using GameHub.Service.Battleship;
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
    public partial class BattleshipView : Window
    {
        BattleshipRound round;
        BattleshipPlayer currentPlayer;
        List<Button> buttons;

        public BattleshipView(BattleshipRound round)
        {
            InitializeComponent();
            this.round = round;

            buttons = new List<Button>()
            {
                btn00, btn01, btn02, btn03, btn04, btn05, btn06, btn07,
                btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17,
                btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27,
                btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37,
                btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47,
                btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57,
                btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67,
                btn70, btn71, btn72, btn73, btn74, btn75, btn76, btn77
            };

            SetNextPlayer();
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Background != Brushes.Transparent)
                return;

            string[] stringGridPosition = btn.Tag.ToString()!.Split(",");
            int[] gridPosition = new int[]
            {
                Convert.ToInt16(stringGridPosition[0]),
                Convert.ToInt16(stringGridPosition[1])
            };

            enumBattleshipShip ship = round.Grid[gridPosition[0], gridPosition[1]];
            SetButtonImage(btn, ship);

            if(ship != enumBattleshipShip.None)
                currentPlayer.SetStrike();

            if(round.CheckEndGame())
            {
                DisableButtons();
                lblPlayerStrikes.Content = currentPlayer.Strikes;
                MessageBox.Show($"Fim da partida.\nVencedor: {round.WinnerPlayer!.Name}");
                return;
            }

            SetNextPlayer();
        }

        private void SetButtonImage(Button btn, enumBattleshipShip ship)
        {
            string imageAsset = "";

            btn.Content = GeneratePlayerNumber(currentPlayer);
            btn.Foreground = Brushes.White;
            btn.FontSize = 6;

            switch (ship)
            {
                case enumBattleshipShip.BigFrontH:
                    imageAsset = "Assets/Battleship/BigFrontH.png";
                    break;
                case enumBattleshipShip.BigMiddleH:
                    imageAsset = "Assets/Battleship/BigMiddleH.png";
                    break;
                case enumBattleshipShip.BigRearH:
                    imageAsset = "Assets/Battleship/BigRearH.png";
                    break;
                case enumBattleshipShip.BigFrontV:
                    imageAsset = "Assets/Battleship/BigFrontV.png";
                    break;
                case enumBattleshipShip.BigMiddleV:
                    imageAsset = "Assets/Battleship/BigMiddleV.png";
                    break;
                case enumBattleshipShip.BigRearV:
                    imageAsset = "Assets/Battleship/BigRearV.png";
                    break;
                case enumBattleshipShip.Small:
                    imageAsset = "Assets/Battleship/Small.png";
                    break;
            }

            if (imageAsset == "")
            {
                btn.Background = Brushes.AliceBlue;
                btn.Foreground = Brushes.Black;
            } else
            {
                Uri resource = new Uri(imageAsset, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
                BitmapFrame bmpFrame = BitmapFrame.Create(streamInfo.Stream);
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.Stretch = Stretch.Uniform;
                imgBrush.ImageSource = bmpFrame;
                btn.Background = imgBrush;
            }
        }

        private int GeneratePlayerNumber(BattleshipPlayer player)
        {
            if (player.PlayerNumber == EnumPlayer.Player1)
            {
                return 1;
            } else
            {
                return 2;
            }
        }

        private void SetNextPlayer()
        {
            if (currentPlayer == round.Player1)
                currentPlayer = round.Player2;
            else if (currentPlayer == round.Player2)
                currentPlayer = round.Player1;
            else
                currentPlayer = round.Player1;

            lblPlayerName.Content = $"{GeneratePlayerNumber(currentPlayer)} - {currentPlayer.Name}";
            lblPlayerStrikes.Content = currentPlayer.Strikes;
        }

        private void NewRound(object sender, RoutedEventArgs e)
        {
            BattleshipRound newRound = new BattleshipRound(round.Player1, round.Player2);

            round = newRound;
            currentPlayer = round.Player1;
            lblPlayerName.Content = $"{GeneratePlayerNumber(currentPlayer)} - {currentPlayer.Name}";
            lblPlayerStrikes.Content = 0;

            foreach (var btn in buttons)
            {
                btn.IsEnabled = true;
                btn.Background = Brushes.Transparent;
                btn.Foreground = Brushes.Transparent;
                btn.Content = "";
            }
        }

        private void DisableButtons()
        {
            foreach (var btn in buttons)
                btn.IsEnabled = false;
        }
    }
}
