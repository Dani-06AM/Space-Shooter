namespace Space_Shooter
{
    partial class SpaceShooter
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceShooter));
            this.BgSpeed = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.UpTimer = new System.Windows.Forms.Timer(this.components);
            this.DownTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftTimer = new System.Windows.Forms.Timer(this.components);
            this.RightTimer = new System.Windows.Forms.Timer(this.components);
            this.BulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyBulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.btnReplay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // BgSpeed
            // 
            this.BgSpeed.Enabled = true;
            this.BgSpeed.Interval = 10;
            this.BgSpeed.Tick += new System.EventHandler(this.BgSpeed_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(270, 400);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // UpTimer
            // 
            this.UpTimer.Interval = 5;
            this.UpTimer.Tick += new System.EventHandler(this.UpTimer_Tick);
            // 
            // DownTimer
            // 
            this.DownTimer.Interval = 5;
            this.DownTimer.Tick += new System.EventHandler(this.DownTimer_Tick);
            // 
            // LeftTimer
            // 
            this.LeftTimer.Interval = 5;
            this.LeftTimer.Tick += new System.EventHandler(this.LeftTimer_Tick);
            // 
            // RightTimer
            // 
            this.RightTimer.Interval = 5;
            this.RightTimer.Tick += new System.EventHandler(this.RightTimer_Tick);
            // 
            // BulletsTimer
            // 
            this.BulletsTimer.Enabled = true;
            this.BulletsTimer.Interval = 20;
            this.BulletsTimer.Tick += new System.EventHandler(this.BulletsTimer_Tick);
            // 
            // EnemyTimer
            // 
            this.EnemyTimer.Enabled = true;
            this.EnemyTimer.Tick += new System.EventHandler(this.EnemyTimer_Tick);
            // 
            // EnemyBulletsTimer
            // 
            this.EnemyBulletsTimer.Enabled = true;
            this.EnemyBulletsTimer.Interval = 20;
            this.EnemyBulletsTimer.Tick += new System.EventHandler(this.EnemyBulletsTimer_Tick);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblGameOver.Location = new System.Drawing.Point(200, 120);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(190, 80);
            this.lblGameOver.TabIndex = 1;
            this.lblGameOver.Text = "label1";
            this.lblGameOver.Visible = false;
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(213, 221);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(166, 64);
            this.btnReplay.TabIndex = 2;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Visible = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(213, 303);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(166, 64);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SpaceShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.Player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "SpaceShooter";
            this.Text = "Space Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceShooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceShooter_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer BgSpeed;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer UpTimer;
        private System.Windows.Forms.Timer DownTimer;
        private System.Windows.Forms.Timer LeftTimer;
        private System.Windows.Forms.Timer RightTimer;
        private System.Windows.Forms.Timer BulletsTimer;
        private System.Windows.Forms.Timer EnemyTimer;
        private System.Windows.Forms.Timer EnemyBulletsTimer;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnExit;
    }
}

