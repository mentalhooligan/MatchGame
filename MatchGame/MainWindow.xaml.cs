using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
                int index = random.Next(animalEmoji.Count); //assigns a random number from 0 to amount of left emojis in the emoji list
                string nextEmoji = animalEmoji[index]; // gets a random emoji
                textBlock.Text = nextEmoji; // puts that random emoji into the block in the window
                animalEmoji.RemoveAt(index); // removes used emoji from the list of emojis
            }
        }
    }
}
