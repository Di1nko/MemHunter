using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-TEN18JJB\\RATH; Initial Catalog=MemeHunter; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Leaderboard"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Leaderboard"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            Table_Players.ItemsSource = dt.DefaultView; // Сам вывод 
            connection.Close();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Hide();
        }
    }
}
