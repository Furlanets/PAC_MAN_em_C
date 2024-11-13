using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace JOGO001
{
    public partial class Form1 : Form
    {
        int[,] tabuleiro = new int[50,60];
        Random rnd = new Random();
        int vlCol, vlLin;

        //TECLA DIGITADA
        int tecla=0;
        int contPontos;

        //POSIÇÃO NO TABULEIRO
        int auxvlCol = 0;
        int auxvlLin = 0;

        //STATUS DO GAME
        // 0 - off
        // 1 - on
        int statusGame = 0;


        public int mover(int status, int tecla)
        {
            
        }

        public void inicializaTabuleiro()
        {
            for (int lin = 0; lin < 50; lin++)
                for (int col = 0; col < 60; col++)
                {
                    tabuleiro[lin, col] = 0;
                    int vl = rnd.Next(0, 100);
                    if (vl > 90)
                        tabuleiro[lin, col] = -1;
                }
            vlCol = rnd.Next(0, 60);
            vlLin = rnd.Next(0, 50);
            tabuleiro[vlLin, vlCol] = 1;
            contPontos = 0;
            lblMensagem.Text = "PONTOS: " + contPontos.ToString();
        }

        public Form1()
        {
            InitializeComponent();
            inicializaTabuleiro();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 1);
            Pen BluePen = new Pen(Color.Blue, 1);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            SolidBrush WhiteBrush = new SolidBrush(Color.White);
            SolidBrush GreenBrush = new SolidBrush(Color.Green);

            for (int lin = 0; lin < 50; lin++)
                for (int col = 0; col < 60; col++)
                {
                    if (tabuleiro[lin, col] ==0)
                    {
                        e.Graphics.FillRectangle(WhiteBrush, col * 10, lin * 10, (col + 1) * 10, (lin + 1) * 10);
                        e.Graphics.DrawRectangle(blackPen, col*10, lin*10, (col+1)*10, (lin+1)*10);
                    }
                    else
                    if(tabuleiro[lin, col] == -1)
                    {
                        e.Graphics.FillRectangle(BlueBrush, col * 10, lin * 10, (col + 1) * 10, (lin + 1) * 10);
                        e.Graphics.DrawRectangle(blackPen, col * 10, lin * 10, (col + 1) * 10, (lin + 1) * 10);
                    }
                    else
                    if (tabuleiro[lin, col] == 1)
                    {
                        e.Graphics.FillRectangle(GreenBrush, col * 10, lin * 10, (col + 1) * 10, (lin + 1) * 10);
                        e.Graphics.DrawRectangle(blackPen, col * 10, lin * 10, (col + 1) * 10, (lin + 1) * 10);
                    }
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tecla=mover(statusGame ,tecla);

            pictureBox1.Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbTeclas_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbTeclas_KeyDown(object sender, KeyEventArgs e)
        {
            tecla = e.KeyValue;
            tecla=mover(statusGame,tecla);
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            inicializaTabuleiro();
            pictureBox1.Invalidate();
            timer1.Enabled = true;
            statusGame = 1;
            txbTeclas.Focus();
        }

        private void btnNivelHard_Click(object sender, EventArgs e)
        {
            timer1.Interval = 20;
        }

        private void btnNivelDificil_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void btnNivelMedio_Click(object sender, EventArgs e)
        {
            timer1.Interval = 75;
        }

        private void btnNivelFacil_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


        }
    }
}
