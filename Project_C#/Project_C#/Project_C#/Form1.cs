using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {

        bool go_left, go_right;
        int speed = 0;
        int score = 0;
        int missed = 0;

        Random rand_x = new Random();
        Random rand_y = new Random();

        PictureBox splash = new PictureBox();

        public Form1()
        {
            InitializeComponent();
            restart_game();
        }

        private void main_game_timer_event(object sender, EventArgs e)
        {

            txt_score.Text = "Saved: " + score;
            txt_miss.Text = "Missed " + missed;

            if (go_left == true && player.Left > 0)
            {
                player.Left -= 12;
                player.Image = Project_C_.Properties.Resources.wolf__left;
            }

            if (go_right == true && player.Left + player.Width < ClientSize.Width)
            {
                player.Left += 12;
                player.Image = Project_C_.Properties.Resources.wolf_right;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top += speed;



                    if (x.Top + x.Height > this.ClientSize.Height)
                    {

                        splash.Image = Project_C_.Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;

                        this.Controls.Add(splash);


                        x.Top = rand_y.Next(80, 300) * -1;
                        x.Left = rand_x.Next(5, this.ClientSize.Width - x.Width);

                        missed += 1;
                    }

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = rand_y.Next(80, 300) * -1;
                        x.Left = rand_x.Next(5, this.ClientSize.Width - x.Width);
                        score += 1;
                    }

                }
            }
            if (score == 10) speed = 10;

            if (missed > 5)
            {
                game_timer.Stop();
                MessageBox.Show("GAME OVER" + Environment.NewLine + "you've lost more 5 eggs"
                    + Environment.NewLine + "click OK to retry");
                restart_game();
            }

        }

        private void key_is_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                go_left = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                go_right = true;
            }
        }

        private void key_is_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                go_left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                go_right = false;
            }
        }

        private void restart_game()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top = rand_y.Next(80, 300) * -1;
                    x.Left = rand_x.Next(5, this.ClientSize.Width - x.Width);
                    
                }
            }

            player.Left = this.ClientSize.Width / 2;
            player.Image = Project_C_.Properties.Resources.wolf__left;

            score = 0;
            missed = 0;
            speed = 8;

            go_left = false;
            go_right = false;

            game_timer.Start();
        }
    }
}

