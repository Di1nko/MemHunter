using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using System.Xml.Xsl;


namespace course_work
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class Training : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight;
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random rand = new Random();

        private int enemySpriteCounter = 0;
        private int enemyCounter = 100;
        private int playerSpeed = 30;
        private int limit = 50;
        private int score = 0;
        private int damage = 0;
        private int enemySpeed = 10;
        private string Mem = "D:/course_work — копия/Images/TrainingMem.png";

        private Rect playerHitBox;

        //private double _height = SystemParameters.WorkArea.Height;
        //private double _width = SystemParameters.WorkArea.Width;

        public Training()
        {

            InitializeComponent();


            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            Training_Can.Focus();

            ImageBrush bg = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("D://course_work/Images/Fon.png")),
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, 1, 1),
                ViewportUnits = BrushMappingMode.RelativeToBoundingBox
            };
            Training_Can.Background = bg;


            ImageBrush playerImage = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("D://course_work/Images/MainShip.png"))
            };
            player.Fill = playerImage;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);

            enemyCounter -= 1;

            scoreText.Content = "Score: " + score;
            damageText.Content = "Damage: " + damage;

            if (enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }

            if (moveLeft == true && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
            }

            if (moveRight == true && Canvas.GetLeft(player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
            }

            foreach (var x in Training_Can.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);

                    Rect bulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x);
                    }


                    foreach (var y in Training_Can.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);

                            if (bulletHitBox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);
                                score++;
                            }
                        }
                    }
                }

                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed);

                    if (Canvas.GetTop(x) > 615)
                    {
                        itemRemover.Add(x);
                        damage += 10;
                    }

                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        itemRemover.Add(x);
                        damage += 5;
                    }
                }
            }

            foreach (Rectangle i in itemRemover)
            {
                Training_Can.Children.Remove(i);
            }

            if (score > 5)
            {
                limit = 20;
                enemySpeed = 15;
            }

            if (damage > 99)
            {
                gameTimer.Stop();
                damageText.Content = "Damage: 100";
                damageText.Foreground = Brushes.Red;
                MessageBox.Show("Вы проиграли!!");
                this.Close();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = true;
            }

            if (e.Key == Key.Right)
            {
                moveRight = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = false;
            }

            if (e.Key == Key.Right)
            {
                moveRight = false;
            }

            if (e.Key == Key.Space)
            {
                Rectangle newBullet = new Rectangle()
                {
                    Tag = "bullet",
                    Height = 20,
                    Width = 5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };

                Canvas.SetLeft(newBullet, Canvas.GetLeft(player) + player.Width / 2);
                Canvas.SetTop(newBullet, Canvas.GetTop(player) - newBullet.Height);

                Training_Can.Children.Add(newBullet);
            }
        }

        public void MakeEnemies()
        {
            ImageBrush enemySprite = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(Mem))
            };

            Rectangle newEnemy = new Rectangle()
            {
                Tag = "enemy",
                Height = 70,
                Width = 65,
                Fill = enemySprite
            };

            Canvas.SetTop(newEnemy, -200);
            Canvas.SetLeft(newEnemy, rand.Next(30,500));

            Training_Can.Children.Add(newEnemy);
        }
    }
}
