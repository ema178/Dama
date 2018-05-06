namespace DamaPaci2
{
    partial class Grafica
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grafica));
            this.back = new System.Windows.Forms.Panel();
            this.Stato = new System.Windows.Forms.Label();
            this.Suggerimenti = new System.Windows.Forms.Label();
            this.Istruzioni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.Location = new System.Drawing.Point(12, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(394, 433);
            this.back.TabIndex = 0;
            this.back.Resize += new System.EventHandler(this.ResizeScacchiera);
            // 
            // Stato
            // 
            this.Stato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stato.AutoSize = true;
            this.Stato.BackColor = System.Drawing.Color.Transparent;
            this.Stato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stato.Location = new System.Drawing.Point(673, 120);
            this.Stato.Name = "Stato";
            this.Stato.Size = new System.Drawing.Size(12, 18);
            this.Stato.TabIndex = 1;
            this.Stato.Text = ".";
            this.Stato.Click += new System.EventHandler(this.Stato_Click);
            // 
            // Suggerimenti
            // 
            this.Suggerimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Suggerimenti.BackColor = System.Drawing.Color.Transparent;
            this.Suggerimenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Suggerimenti.ForeColor = System.Drawing.Color.Black;
            this.Suggerimenti.Location = new System.Drawing.Point(673, 55);
            this.Suggerimenti.Name = "Suggerimenti";
            this.Suggerimenti.Size = new System.Drawing.Size(112, 65);
            this.Suggerimenti.TabIndex = 3;
            this.Suggerimenti.Text = "...";
            this.Suggerimenti.Click += new System.EventHandler(this.Suggerimenti_Click);
            // 
            // Istruzioni
            // 
            this.Istruzioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Istruzioni.AutoSize = true;
            this.Istruzioni.BackColor = System.Drawing.Color.DimGray;
            this.Istruzioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Istruzioni.ForeColor = System.Drawing.Color.White;
            this.Istruzioni.Location = new System.Drawing.Point(742, 398);
            this.Istruzioni.Name = "Istruzioni";
            this.Istruzioni.Size = new System.Drawing.Size(46, 47);
            this.Istruzioni.TabIndex = 4;
            this.Istruzioni.Text = "?";
            this.Istruzioni.UseVisualStyleBackColor = false;
            this.Istruzioni.Click += new System.EventHandler(this.Istruzioni_Click);
            // 
            // Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.Istruzioni);
            this.Controls.Add(this.Suggerimenti);
            this.Controls.Add(this.Stato);
            this.Controls.Add(this.back);
            this.Name = "Grafica";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel back;
        public System.Windows.Forms.Label Stato;
        public System.Windows.Forms.Label Suggerimenti;
        private System.Windows.Forms.Button Istruzioni;
    }
}

