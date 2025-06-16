using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Space_Shooter
{
    public partial class SpaceShooter : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] stars;
        int backgroundSpeed;
        int playerSpeed;
        Random rnd;

        PictureBox[] bullets;
        int bulletSpeed;

        PictureBox[] enemies;
        int enemySpeed;

        PictureBox[] enemiesBullets;
        int enemyBulletSpeed;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameIsOver;

        public SpaceShooter()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            score = 0;
            level = 1;
            difficulty = 9;
            pause = false;
            gameIsOver = false;

            rnd = new Random();
            backgroundSpeed = 4;
            playerSpeed = 4;
            enemySpeed = 4;

            bulletSpeed = 20;
            enemyBulletSpeed = 4;

            bullets = new PictureBox[3];
            enemiesBullets = new PictureBox[10];

            //Create WMP.
            gameMedia = new WindowsMediaPlayer();
            shootMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            //Load the songs and sounds.
            gameMedia.URL = "songs\\GameSong.mp3";
            shootMedia.URL = "songs\\shoot.mp3";
            explosion.URL = "songs\\boom.mp3";

            //Setup songs.
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 4;
            shootMedia.settings.volume = 1;
            explosion.settings.volume = 5;

            //Load images.
            Image bullet = Image.FromFile(@"asserts\munition.png");

            Image enemy1 = Image.FromFile(@"asserts\\E1.png");
            Image enemy2 = Image.FromFile(@"asserts\\E2.png");
            Image enemy3 = Image.FromFile(@"asserts\\E3.png");
            Image boss1 = Image.FromFile(@"asserts\\Boss1.png");
            Image boss2 = Image.FromFile(@"asserts\\Boss2.png");

            enemies = new PictureBox[10];

            //New enemies.
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemy2;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy3;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy3;
            enemies[8].Image = enemy2;
            enemies[9].Image = boss2;

            //New Bullets.
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].Size = new Size(8, 8);
                bullets[i].Image = bullet;
                bullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(bullets[i]);
            }

            //Enemy Bullets.
            for (int i = 0; i < enemiesBullets.Length; i++)
            {
                enemiesBullets[i] = new PictureBox();
                enemiesBullets[i].Size = new Size(2, 25);
                enemiesBullets[i].Visible = false;
                enemiesBullets[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemiesBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesBullets[i]);
            }

            stars = new PictureBox[20];
            

            //New Stars.
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.White;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                this.Controls.Add(stars[i]);

            }

            gameMedia.controls.play();
        }

        //TIMERS.
        //Background Timer.
        private void BgSpeed_Tick(object sender, EventArgs e)
        {
            //Timer mueve las estrellas del BG.
            for (int i = 0; i < stars.Length/2; i++)
            {
                stars[i].Top += backgroundSpeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length/2; i < stars.Length;  i++)
            {
                stars[i].Top += backgroundSpeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        //Movement Timers.
        private void UpTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void DownTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void LeftTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }
        }
        //End Timers.

        //Keys.
        private void SpaceShooter_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Up)
                {
                    UpTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftTimer.Start();
                }
                if (e.KeyCode == Keys.Right)
                {
                    RightTimer.Start();
                }
            }
            
        }

        private void SpaceShooter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UpTimer.Stop();
            }
            if (e.KeyCode == Keys.Down)
            {
                DownTimer.Stop();
            }
            if (e.KeyCode == Keys.Left)
            {
                LeftTimer.Stop();
            }
            if (e.KeyCode == Keys.Right)
            {
                RightTimer.Stop();
            }
            
            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        lblGameOver.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        lblGameOver.Location = new Point(this.Width / 2 - 120, 150);
                        lblGameOver.Text = "PAUSED";
                        lblGameOver.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
            
        }
        //End Keys.
        
        //Bullets.
        private void BulletsTimer_Tick(object sender, EventArgs e)
        {
            shootMedia.controls.play();

            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Top > 0)
                {
                    bullets[i].Visible = true;
                    bullets[i].Top -= bulletSpeed;

                    Collision();
                }
                else
                {
                    bullets[i].Visible = false;
                    bullets[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        //Enemy Timer.
        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemySpeed);
        }

        //Move enemies.
        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        } 

        //COLLISIONS.
        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (bullets[0].Bounds.IntersectsWith(enemies[i].Bounds)
                    || bullets[1].Bounds.IntersectsWith(enemies[i].Bounds)
                    || bullets[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();
                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }

                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 20;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("");
                }

            }
        }

        //GAME OVER.
        private void GameOver(String str)
        {
            lblGameOver.Text = str;
            lblGameOver.Location = new Point(142, 120);
            lblGameOver.Visible = true;
            btnReplay.Visible = true;
            btnExit.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        private void StopTimers()
        {
            BgSpeed.Stop();
            BulletsTimer.Stop();
            EnemyTimer.Stop();
            EnemyBulletsTimer.Stop();
        }

        private void StartTimers()
        {
            BgSpeed.Start();
            BulletsTimer.Start();
            EnemyTimer.Start();
            EnemyBulletsTimer.Start();
        }

        //Enemy Bullets Timer.
        private void EnemyBulletsTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemiesBullets.Length; i++)
            {
                if (enemiesBullets[i].Top < this.Height)
                {
                    enemiesBullets[i].Visible = true;
                    enemiesBullets[i].Top += enemyBulletSpeed;

                    CollisionWithEnemyBullets();
                }
                else
                {
                    enemiesBullets[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemiesBullets[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemyBullets()
        {
            for (int i = 0; i < enemiesBullets.Length; i++)
            {
                if (enemiesBullets[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesBullets[i].Visible = false;
                    explosion.settings.volume = 20;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
