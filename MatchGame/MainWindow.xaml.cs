﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick; 
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed/10F).ToString("0.0");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + "ur stupid haha";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>() //creates a list of emojis
            {
                "🐵", "🐵" ,
                "🐶", "🐶" ,
                "🐺", "🐺" ,
                "🦁", "🦁" ,
                "🦒", "🦒" ,
                "🦊", "🦊" ,
                "🦝", "🦝" ,
                "🐮", "🐮"
            };
            Random random = new Random(); // creates a random number generator

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) // for each textblock in maingrid does this
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); //assigns a random number from 0 to amount of left emojis in the emoji list
                    string nextEmoji = animalEmoji[index]; // gets a random emoji
                    textBlock.Text = nextEmoji; // puts that random emoji into the block in the window
                    animalEmoji.RemoveAt(index); // removes used emoji from the list of emojis
                }
            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                findingMatch = false;
                textBlock.Visibility = Visibility.Hidden;

            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound==8)
            {   
                SetUpGame();
            }
        }
    }
}
