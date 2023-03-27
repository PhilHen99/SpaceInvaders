namespace SpaceInvaders
{
    partial class Invaders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblscore = new System.Windows.Forms.Label();
            this.TmrGame = new System.Windows.Forms.Timer(this.components);
            this.picrick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picrick)).BeginInit();
            this.SuspendLayout();
            // 
            // lblscore
            // 
            this.lblscore.AutoSize = true;
            this.lblscore.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblscore.Location = new System.Drawing.Point(12, 533);
            this.lblscore.Name = "lblscore";
            this.lblscore.Size = new System.Drawing.Size(103, 16);
            this.lblscore.TabIndex = 0;
            this.lblscore.Text = "Puntuación:  0";
            // 
            // TmrGame
            // 
            this.TmrGame.Interval = 20;
            this.TmrGame.Tick += new System.EventHandler(this.GameTimer);
            // 
            // picrick
            // 
            this.picrick.Image = global::SpaceInvaders.Properties.Resources.picrick;
            this.picrick.Location = new System.Drawing.Point(333, 499);
            this.picrick.Name = "picrick";
            this.picrick.Size = new System.Drawing.Size(100, 50);
            this.picrick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picrick.TabIndex = 1;
            this.picrick.TabStop = false;
            this.picrick.Click += new System.EventHandler(this.picrick_Click);
            // 
            // Invaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.picrick);
            this.Controls.Add(this.lblscore);
            this.Name = "Invaders";
            this.Text = "SpaceInvaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KUp);
            ((System.ComponentModel.ISupportInitialize)(this.picrick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblscore;
        private System.Windows.Forms.PictureBox picrick;
        private System.Windows.Forms.Timer TmrGame;
    }
}

