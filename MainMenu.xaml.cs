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

namespace course_work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void Start_game_Click(object sender, RoutedEventArgs e)
        {
            Levels levels = new Levels();
            levels.Show();
            Hide();
        }

        private void Training_Click(object sender, RoutedEventArgs e)
        {
            Training Training = new Training();
            Training.Show();
            Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Show();
            Hide();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
            Hide();
        }
    }
}
