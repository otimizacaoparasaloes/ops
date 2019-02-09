namespace OPS
{
    partial class frmCarregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarregar));
            this.lblCarregar = new System.Windows.Forms.Label();
            this.pgbCarregar = new System.Windows.Forms.ProgressBar();
            this.tmrCarregar = new System.Windows.Forms.Timer(this.components);
            this.ptbCarregar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCarregar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCarregar
            // 
            this.lblCarregar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarregar.AutoSize = true;
            this.lblCarregar.BackColor = System.Drawing.Color.Transparent;
            this.lblCarregar.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarregar.ForeColor = System.Drawing.Color.White;
            this.lblCarregar.Location = new System.Drawing.Point(37, 148);
            this.lblCarregar.Name = "lblCarregar";
            this.lblCarregar.Size = new System.Drawing.Size(168, 16);
            this.lblCarregar.TabIndex = 0;
            this.lblCarregar.Text = "Carregando informações ...";
            this.lblCarregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarregar.UseWaitCursor = true;
            // 
            // pgbCarregar
            // 
            this.pgbCarregar.Location = new System.Drawing.Point(106, 207);
            this.pgbCarregar.Name = "pgbCarregar";
            this.pgbCarregar.Size = new System.Drawing.Size(34, 20);
            this.pgbCarregar.TabIndex = 1;
            // 
            // tmrCarregar
            // 
            this.tmrCarregar.Enabled = true;
            this.tmrCarregar.Tick += new System.EventHandler(this.tmrCarregar_Tick);
            // 
            // ptbCarregar
            // 
            this.ptbCarregar.BackColor = System.Drawing.Color.Transparent;
            this.ptbCarregar.Location = new System.Drawing.Point(74, 194);
            this.ptbCarregar.Name = "ptbCarregar";
            this.ptbCarregar.Size = new System.Drawing.Size(100, 50);
            this.ptbCarregar.TabIndex = 2;
            this.ptbCarregar.TabStop = false;
            // 
            // frmCarregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OPS.Properties.Resources.Splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.ptbCarregar);
            this.Controls.Add(this.pgbCarregar);
            this.Controls.Add(this.lblCarregar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCarregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otimização para Salões";
            this.Load += new System.EventHandler(this.frmCarregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCarregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarregar;
        private System.Windows.Forms.ProgressBar pgbCarregar;
        private System.Windows.Forms.Timer tmrCarregar;
        private System.Windows.Forms.PictureBox ptbCarregar;
    }
}