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
using System.Windows.Shapes;

namespace course_work
{
    /// <summary>
    /// Логика взаимодействия для Levels.xaml
    /// </summary>
    public partial class Levels : Window
    {
        public string Mem { get; set; }
        public string name { get; set; }
        public int level_num { get; set; }
        public Levels()
        {
            InitializeComponent();
        }


        private void Level_1_Click(object sender, RoutedEventArgs e)
        {
            level_num = 1;
            Mem = "D://course_work/Images/MemLV_1.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();

        }

        private void Level_2_Click(object sender, RoutedEventArgs e)
        {
            level_num = 2;
            Mem = "D://course_work/Images/MemLV_2.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();
        }

        private void Level_3_Click(object sender, RoutedEventArgs e)
        {
            level_num = 3;
            Mem = "D://course_work/Images/MemLV_3.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();
        }

        private void Level_4_Click(object sender, RoutedEventArgs e)
        {
            level_num = 4;
            Mem = "D://course_work/Images/MemLV_4.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();
        }

        private void Level_5_Click(object sender, RoutedEventArgs e)
        {
            level_num = 5;
            Mem = "D://course_work/Images/MemLV_5.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();
        }

        private void Level_6_Click(object sender, RoutedEventArgs e)
        {
            level_num = 6;
            Mem = "D://course_work/Images/MemLV_6.png";
            name = Player_Name.Text;
            if (name == "")
            {
                name = "Unknown Player";
            }
            MainGame mainGame = new MainGame(Mem, name, level_num);
            mainGame.Show();
            Hide();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Hide();
        }
    }
}
