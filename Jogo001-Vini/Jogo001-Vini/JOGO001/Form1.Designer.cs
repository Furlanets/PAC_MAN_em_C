namespace JOGO001
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMensagem = new System.Windows.Forms.Label();
            this.txbTeclas = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnNivelHard = new System.Windows.Forms.Button();
            this.btnNivelDificil = new System.Windows.Forms.Button();
            this.btnNivelFacil = new System.Windows.Forms.Button();
            this.btnNivelMedio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(618, 461);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(248, 51);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(618, 12);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(35, 13);
            this.lblMensagem.TabIndex = 2;
            this.lblMensagem.Text = "label1";
            // 
            // txbTeclas
            // 
            this.txbTeclas.AcceptsReturn = true;
            this.txbTeclas.Location = new System.Drawing.Point(618, 41);
            this.txbTeclas.Name = "txbTeclas";
            this.txbTeclas.Size = new System.Drawing.Size(248, 20);
            this.txbTeclas.TabIndex = 3;
            this.txbTeclas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTeclas_KeyDown);
            this.txbTeclas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTeclas_KeyPress);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(618, 189);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(248, 52);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "GAME - START";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnNivelHard
            // 
            this.btnNivelHard.Location = new System.Drawing.Point(618, 154);
            this.btnNivelHard.Name = "btnNivelHard";
            this.btnNivelHard.Size = new System.Drawing.Size(248, 23);
            this.btnNivelHard.TabIndex = 5;
            this.btnNivelHard.Text = "HARD";
            this.btnNivelHard.UseVisualStyleBackColor = true;
            this.btnNivelHard.Click += new System.EventHandler(this.btnNivelHard_Click);
            // 
            // btnNivelDificil
            // 
            this.btnNivelDificil.Location = new System.Drawing.Point(618, 125);
            this.btnNivelDificil.Name = "btnNivelDificil";
            this.btnNivelDificil.Size = new System.Drawing.Size(248, 23);
            this.btnNivelDificil.TabIndex = 6;
            this.btnNivelDificil.Text = "DIFÍCIL";
            this.btnNivelDificil.UseVisualStyleBackColor = true;
            this.btnNivelDificil.Click += new System.EventHandler(this.btnNivelDificil_Click);
            // 
            // btnNivelFacil
            // 
            this.btnNivelFacil.Location = new System.Drawing.Point(618, 67);
            this.btnNivelFacil.Name = "btnNivelFacil";
            this.btnNivelFacil.Size = new System.Drawing.Size(248, 23);
            this.btnNivelFacil.TabIndex = 7;
            this.btnNivelFacil.Text = "FÁCIL";
            this.btnNivelFacil.UseVisualStyleBackColor = true;
            this.btnNivelFacil.Click += new System.EventHandler(this.btnNivelFacil_Click);
            // 
            // btnNivelMedio
            // 
            this.btnNivelMedio.Location = new System.Drawing.Point(618, 96);
            this.btnNivelMedio.Name = "btnNivelMedio";
            this.btnNivelMedio.Size = new System.Drawing.Size(248, 23);
            this.btnNivelMedio.TabIndex = 8;
            this.btnNivelMedio.Text = "MÉDIO";
            this.btnNivelMedio.UseVisualStyleBackColor = true;
            this.btnNivelMedio.Click += new System.EventHandler(this.btnNivelMedio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 525);
            this.Controls.Add(this.btnNivelMedio);
            this.Controls.Add(this.btnNivelFacil);
            this.Controls.Add(this.btnNivelDificil);
            this.Controls.Add(this.btnNivelHard);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.txbTeclas);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "JOGO 001 - EXEMPLO - VERSÃO 1.0";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.TextBox txbTeclas;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnNivelHard;
        private System.Windows.Forms.Button btnNivelDificil;
        private System.Windows.Forms.Button btnNivelFacil;
        private System.Windows.Forms.Button btnNivelMedio;
    }
}

