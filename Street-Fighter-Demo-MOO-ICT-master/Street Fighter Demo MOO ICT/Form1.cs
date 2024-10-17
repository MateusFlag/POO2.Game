using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Street_Fighter_Demo_MOO_ICT
{
    public partial class Form1 : Form
    {
        Image player;
        Image background;
        Image drum;
        Image fireball;

        int playerX = 0;
        int playerY = 300;

        int drumX = 450;
        int drumY = 335;

        int fireballX;
        int fireballY;

        int jumpSpeed = 0;
        int jumpHeight = 100;
        bool isJumping = false;

        int drumMoveTime = 0;
        int actionStrength = 0;
        int endFrame = 0;
        int backgroundPosition = 0;
        int totalFrame = 0;
        int bg_number = 0;

        float num;

        bool goLeft, goRight;
        bool directionPressed;
        bool playingAction;
        bool shotFireBall;

        List<string> background_images = new List<string>();

        public Form1(string characterName)
        {
            InitializeComponent();
            SetUpForm(characterName);
        }

        private void SetUpForm(string characterName)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            background_images = System.IO.Directory.GetFiles("background", "*.jpg").ToList();
            background = Image.FromFile(background_images[bg_number]);

            // Carregar sprites com base no personagem selecionado
            if (characterName == "Personagem 1")
            {
                player = Image.FromFile("standing.gif");
            }
            else if (characterName == "Personagem 2")
            {
                player = Image.FromFile("character2_standing.gif");
            }

            drum = Image.FromFile("drum.png");
            SetUpAnimation();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && !directionPressed)
            {
                MovePlayerAnimation("left");
            }
            if (e.KeyCode == Keys.Right && !directionPressed)
            {
                MovePlayerAnimation("right");
            }
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                // Inicia o pulo
                isJumping = true;
                jumpSpeed = -15;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                goLeft = false;
                goRight = false;
                directionPressed = false;
                ResetPlayer();
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(background, new Point(backgroundPosition, 0));
            e.Graphics.DrawImage(player, new Point(playerX, playerY));
            e.Graphics.DrawImage(drum, new Point(drumX, drumY));

            if (shotFireBall)
            {
                e.Graphics.DrawImage(fireball, new Point(fireballX, fireballY));
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            this.Invalidate();
            ImageAnimator.UpdateFrames();
            MovePlayerandBackground();
            CheckPunchHit();

            // Lógica de pulo
            if (isJumping)
            {
                playerY += jumpSpeed;
                jumpSpeed += 1;

                if (playerY >= 300)
                {
                    playerY = 300;
                    isJumping = false;
                }
            }

            if (playingAction)
            {
                if (num < totalFrame)
                {
                    num += 0.5f;
                }
            }
            if (num == totalFrame)
            {
                ResetPlayer();
            }

            // Lógica do fireball
            if (shotFireBall)
            {
                fireballX += 10;
                CheckFireballHit();
            }

            if (fireballX > this.ClientSize.Width)
            {
                shotFireBall = false;
            }

            if (!shotFireBall && num > endFrame && drumMoveTime == 0 && actionStrength == 30)
            {
                ShootFireball();
            }

            if (drumMoveTime > 0)
            {
                drumMoveTime--;
                drumX += 10;
                drum = Image.FromFile("hitdrum.png");
            }
            else
            {
                drum = Image.FromFile("drum.png");
                drumMoveTime = 0;
            }

            if (drumX > this.ClientSize.Width)
            {
                drumMoveTime = 0;
                drumX = 300;
            }
        }

        private void SetUpAnimation()
        {
            ImageAnimator.Animate(player, this.OnFrameChangedHandler);
            FrameDimension dimentions = new FrameDimension(player.FrameDimensionsList[0]);
            totalFrame = player.GetFrameCount(dimentions);
            endFrame = totalFrame - 3;
        }

        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void MovePlayerandBackground()
        {
            if (goLeft)
            {
                if (playerX > 0)
                {
                    playerX -= 6;
                }

                if (backgroundPosition < 0 && playerX < 100)
                {
                    backgroundPosition += 5;
                    drumX += 5;
                }

            }
            if (goRight)
            {
                if (playerX + player.Width < this.ClientSize.Width)
                {
                    playerX += 6;
                }

                if (backgroundPosition + background.Width > this.ClientSize.Width + 5 && playerX > 650)
                {
                    backgroundPosition -= 5;
                    drumX -= 5;
                }

            }
        }

        private void MovePlayerAnimation(string direction)
        {
            if (direction == "left")
            {
                goLeft = true;
                player = Image.FromFile("backwards.gif");
            }
            if (direction == "right")
            {
                goRight = true;
                player = Image.FromFile("forwards.gif");
            }

            directionPressed = true;
            playingAction = false;
            SetUpAnimation();
        }

        private void ResetPlayer()
        {
            player = Image.FromFile("standing.gif");
            SetUpAnimation();
            num = 0;
            playingAction = false;
        }

        // Outros métodos como SetPlayerAction, ShootFireball, CheckPunchHit, etc. permanecem os mesmos
    }
}
