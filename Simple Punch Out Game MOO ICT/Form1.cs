using System.Runtime.InteropServices.Marshalling;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        bool playerBlock = false;
        bool enemyBlock = false;
        Random random = new Random();
        int enemySpeed = 5;
        int index = 0;
        int playerHealth = 100;
        int enemyHealth = 100;
        List<string> enemyAttack = new List<string> { "left", "right", "block"};

        //Adicionar variáveis para consertar bugs
        private bool onCooldown = false;
        private readonly System.Windows.Forms.Timer cooldownTimer;
        private bool leftPressed = false; //Trata para se a tecla esquerda está pressionada
        private bool rightPressed = false; //Trata para se a tecla direita está pressionada
        private bool enemyOnCooldown = false;
        private readonly System.Windows.Forms.Timer enemyCooldownTimer;



        public Form1()
        {
            InitializeComponent();
            ResetGame();
            this.DoubleBuffered = true;

            //Inicializa o timer para cooldown dos ataques
            cooldownTimer = new System.Windows.Forms.Timer();
            cooldownTimer.Interval = 200;
            cooldownTimer.Tick += (s, e) =>
            {
                onCooldown = false;
                cooldownTimer.Stop();
            };

            //Cooldown do inimigo
            enemyCooldownTimer = new System.Windows.Forms.Timer();
            enemyCooldownTimer.Interval = 600;
            enemyCooldownTimer.Tick += (s, e) =>
            {
                enemyOnCooldown = false;
                enemyCooldownTimer.Stop();
            };
        }

        //Trata os ataques do inimigo
        private void BoxerAttackTImerEvent(object sender, EventArgs e)
        {
            if (enemyOnCooldown) return;

            index = random.Next(0, enemyAttack.Count);

            if (boxer.Bounds.IntersectsWith(player.Bounds))
            {
                switch (enemyAttack[index])
                {
                    case "left":
                        boxer.Image = Properties.Resources.enemy_punch1;
                        enemyBlock = false;

                        if (!playerBlock)
                        {
                            playerHealth -= 5;
                        }
                        enemyOnCooldown = true;
                        enemyCooldownTimer.Start();
                        break;
                    case "right":
                        boxer.Image = Properties.Resources.enemy_punch2;
                        enemyBlock = false;

                        if (!playerBlock)
                        {
                            playerHealth -= 5;
                        }
                        enemyOnCooldown = true;
                        enemyCooldownTimer.Start();
                        break;
                    case "block":
                        boxer.Image = Properties.Resources.enemy_block;
                        enemyBlock = true;
                        break;
                }
            }
        }

        private void BoxerMoveTimerEvent(object sender, EventArgs e)
        {
            // set up both health bars
            if (playerHealth > 1)
            {
                playerHealthBar.Value = playerHealth;
            }
            if (enemyHealth > 1)
            {
                boxerHealthBar.Value = enemyHealth;
            }


            // move the boxer

            if (!boxer.Bounds.IntersectsWith(player.Bounds))
            {
                boxer.Image = Properties.Resources.enemy_stand;
            }

            boxer.Left += enemySpeed;

            if (boxer.Left > 430)
            {
                enemySpeed = -5;
            }
            if (boxer.Left < 220)
            {
                enemySpeed = 5;
            }

            // check for the end of game scenario

            if (enemyHealth < 1)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();
                MessageBox.Show("You Win, Click OK to Play Again", "Moo Says: ");
                ResetGame();
            }
            if (playerHealth < 1)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();
                MessageBox.Show("Tough Rob Wins, Click OK to Play Again", "Moo Says: ");
                ResetGame();
            }


        }

        //Ataques quando as teclas são pressionadas
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (onCooldown) return; //Não ataca se o CoolDown estiver ativo

            if (e.KeyCode == Keys.Left && !leftPressed) //Lado Esquerdo: Adapta para o jogador não poder 'spammar' ataques
            {
                leftPressed = true;
                DoAttack("left");
            }
            else if (e.KeyCode == Keys.Right && !rightPressed) //Lado Direito: Adapta para o jogador não poder 'spammar' ataques

            {
                rightPressed = true;
                DoAttack("right");
            }
            else if (e.KeyCode == Keys.Down) //Defesa para os ataques inimigos
            {
                player.Image = Properties.Resources.boxer_block;
                playerBlock = true;
            }
        }

        //Tratamento para quando nenhuma tecla é pressionada (o jogador não ataca)
        private void KeyIsUp(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Left) leftPressed = false;
            if (e.KeyCode == Keys.Right) rightPressed = false;

            player.Image = Properties.Resources.boxer_stand;
            playerBlock = false;
        }

        //Método para os ataques
        private void DoAttack(string side)
        {
            if (onCooldown) return;

            onCooldown = true;
            cooldownTimer.Start();

            if (side == "left")
                player.Image = Properties.Resources.boxer_left_punch;
            else
                player.Image = Properties.Resources.boxer_right_punch;
            playerBlock = false;

            if (player.Bounds.IntersectsWith(boxer.Bounds) && !enemyBlock)
            {
                enemyHealth -= 5;
            }
        }

        //Reseta o jogo quando alguém ganha (função já existente/adaptada)
        private void ResetGame()
        {
            BoxerAttackTimer.Start();
            BoxerMoveTimer.Start();
            playerHealth = 100;
            enemyHealth = 100;
            player.Image = Properties.Resources.boxer_stand; //Reseta o jogador para a posição inicial (pose)

            boxer.Left = 400;
        }
    }
}