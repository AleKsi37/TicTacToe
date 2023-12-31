﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
  
    public partial class MainWindow : Window
    {
        private static readonly Player player = new Player();
        private readonly List<Button> winningButtons = new List<Button>();
        private int clicks;

        public class Player
        {
            public string PlayerCharacter { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void ToDoWhenButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderAsButton = (Button)sender;

            try
            {
                clicks++;

                if (senderAsButton.Content == null || senderAsButton.Content.ToString() == "")
                {
                    bool isGameWon = false;
                    if (player.PlayerCharacter == "O")
                    {
                        senderAsButton.Content = "O";
                        isGameWon = IsGameWon(player);
                        if (isGameWon)
                        {
                            ShowWinner(player);
                            StartNewGame();
                        }

                        player.PlayerCharacter = "X";
                    }
                    else
                    {
                        senderAsButton.Content = "X";
                        senderAsButton.Background = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
                        senderAsButton.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF0000");
                        isGameWon = IsGameWon(player);
                        if (isGameWon)
                        {
                            ShowWinner(player);
                            StartNewGame();
                        }

                        
                        if (!isGameWon)
                            player.PlayerCharacter = "O";
                        else
                            player.PlayerCharacter = "X";
                    }
                }
                else
                {
                    clicks--;
                    MessageBox.Show("Kenttä on jo varattu.");
                }

                if (clicks == 9)
                {
                    MessageBox.Show("Peli päättyi tasapeliin.");
                    StartNewGame();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void ShowWinner(Player player)
        {
            foreach (var item in winningButtons)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(116, 189, 0));
            }

            MessageBox.Show("Pelaaja " + player.PlayerCharacter + " voitti!");
        }

        private void StartNewGame()
        {
            winningButtons.Clear();
            clicks = 0;
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(206, 217, 219));
            SolidColorBrush foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            foreach (var item in Spielfeld.Children)
            {
                if (item is Button kaestchen)
                {
                    kaestchen.Content = "";
                    kaestchen.Background = background;
                    kaestchen.Foreground = foreground;
                }
            }
        }

        private bool IsGameWon(Player player)
        {
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_0.Content.ToString() == player.PlayerCharacter && kaestchen_2_0.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_1_0, kaestchen_2_0);
                return true;
            }
            if (kaestchen_0_1.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_1.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_1, kaestchen_1_1, kaestchen_2_1);
                return true;
            }
            if (kaestchen_0_2.Content.ToString() == player.PlayerCharacter && kaestchen_1_2.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_2, kaestchen_1_2, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_1_1, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_0_1.Content.ToString() == player.PlayerCharacter && kaestchen_0_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_0_1, kaestchen_0_2);
                return true;
            }
            if (kaestchen_1_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_1_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_1_0, kaestchen_1_1, kaestchen_1_2);
                return true;
            }
            if (kaestchen_2_0.Content.ToString() == player.PlayerCharacter && kaestchen_2_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_2_0, kaestchen_2_1, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_2.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_0.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_2, kaestchen_1_1, kaestchen_2_0);
                return true;
            }

            return false;
        }

        private void CreateListOfWinningButtons(Button one, Button two, Button three)
        {
            winningButtons.Add(one);
            winningButtons.Add(two);
            winningButtons.Add(three);
        }
    }
}