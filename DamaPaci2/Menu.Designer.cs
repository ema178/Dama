namespace DamaPaci2
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.button1 = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.TwoPlayers = new System.Windows.Forms.CheckBox();
            this.OnePlayer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Play
            // 
            this.Play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Play.BackgroundImage")));
            this.Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Play.ForeColor = System.Drawing.Color.Black;
            this.Play.Location = new System.Drawing.Point(146, 349);
            this.Play.Margin = new System.Windows.Forms.Padding(2);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(87, 93);
            this.Play.TabIndex = 1;
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // TwoPlayers
            // 
            this.TwoPlayers.AutoSize = true;
            this.TwoPlayers.BackColor = System.Drawing.Color.Transparent;
            this.TwoPlayers.Checked = true;
            this.TwoPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TwoPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoPlayers.ForeColor = System.Drawing.Color.White;
            this.TwoPlayers.Location = new System.Drawing.Point(36, 158);
            this.TwoPlayers.Name = "TwoPlayers";
            this.TwoPlayers.Size = new System.Drawing.Size(143, 20);
            this.TwoPlayers.TabIndex = 2;
            this.TwoPlayers.Text = "Player1 VS Player2";
            this.TwoPlayers.UseVisualStyleBackColor = false;
            this.TwoPlayers.CheckedChanged += new System.EventHandler(this.TwoPlayers_CheckedChanged);
            // 
            // OnePlayer
            // 
            this.OnePlayer.AutoCheck = false;
            this.OnePlayer.AutoSize = true;
            this.OnePlayer.BackColor = System.Drawing.Color.Transparent;
            this.OnePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnePlayer.ForeColor = System.Drawing.Color.White;
            this.OnePlayer.Location = new System.Drawing.Point(243, 158);
            this.OnePlayer.Name = "OnePlayer";
            this.OnePlayer.Size = new System.Drawing.Size(108, 20);
            this.OnePlayer.TabIndex = 3;
            this.OnePlayer.Text = "Player VS PC";
            this.OnePlayer.UseVisualStyleBackColor = false;
            this.OnePlayer.CheckedChanged += new System.EventHandler(this.OnePlayer_CheckedChanged);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(381, 469);
            this.Controls.Add(this.OnePlayer);
            this.Controls.Add(this.TwoPlayers);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.CheckBox TwoPlayers;
        private System.Windows.Forms.CheckBox OnePlayer;
    }
}