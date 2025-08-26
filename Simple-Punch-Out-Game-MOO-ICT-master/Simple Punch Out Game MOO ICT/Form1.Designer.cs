namespace Simple_Punch_Out_Game_MOO_ICT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            boxerHealthBar = new ProgressBar();
            playerHealthBar = new ProgressBar();
            player = new PictureBox();
            boxer = new PictureBox();
            BoxerAttackTimer = new System.Windows.Forms.Timer(components);
            BoxerMoveTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxer).BeginInit();
            SuspendLayout();
            // 
            // boxerHealthBar
            // 
            boxerHealthBar.Location = new Point(12, 43);
            boxerHealthBar.Name = "boxerHealthBar";
            boxerHealthBar.Size = new Size(239, 23);
            boxerHealthBar.TabIndex = 0;
            // 
            // playerHealthBar
            // 
            playerHealthBar.Location = new Point(483, 43);
            playerHealthBar.Name = "playerHealthBar";
            playerHealthBar.Size = new Size(239, 23);
            playerHealthBar.TabIndex = 0;
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.boxer_stand;
            player.Location = new Point(348, 407);
            player.Name = "player";
            player.Size = new Size(61, 153);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 1;
            player.TabStop = false;
            // 
            // boxer
            // 
            boxer.BackColor = Color.Transparent;
            boxer.Image = Properties.Resources.enemy_stand;
            boxer.Location = new Point(404, 321);
            boxer.Name = "boxer";
            boxer.Size = new Size(77, 185);
            boxer.SizeMode = PictureBoxSizeMode.AutoSize;
            boxer.TabIndex = 2;
            boxer.TabStop = false;
            // 
            // BoxerAttackTimer
            // 
            BoxerAttackTimer.Enabled = true;
            BoxerAttackTimer.Interval = 500;
            BoxerAttackTimer.Tick += BoxerAttackTImerEvent;
            // 
            // BoxerMoveTimer
            // 
            BoxerMoveTimer.Enabled = true;
            BoxerMoveTimer.Interval = 20;
            BoxerMoveTimer.Tick += BoxerMoveTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(734, 561);
            Controls.Add(player);
            Controls.Add(playerHealthBar);
            Controls.Add(boxerHealthBar);
            Controls.Add(boxer);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Simple Punch Out Game MOO ICT";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxer).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ProgressBar boxerHealthBar;
        private ProgressBar playerHealthBar;
        private PictureBox player;
        private PictureBox boxer;
        private System.Windows.Forms.Timer BoxerAttackTimer;
        private System.Windows.Forms.Timer BoxerMoveTimer;
    }
}