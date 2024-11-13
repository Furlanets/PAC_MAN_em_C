using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace JOGO001
{
    public partial class Form1 : Form
    {
        const int CASA_TIPO_NORMAL = 0;
        const int CASA_TIPO_DESCANSO = 1;
        const int CASA_TIPO_OBSTACULO = 2;

        const int TAB_LINHAS_DEFAULT = 25;
        const int TAB_COLUNAS_DEFAULT = 30;

        int TAB_LINHAS = TAB_LINHAS_DEFAULT;
        int TAB_COLUNAS = TAB_COLUNAS_DEFAULT;

        const int ITEM_TIPO_PECA = 0;
        const int ITEM_TIPO_MEDALHA_OURO = 1;
        const int ITEM_TIPO_MEDALHA_PRATA = 2;
        const int ITEM_TIPO_MEDALHA_BRONZE = 3;

        const int PERSONAGEM_TIPO_FANTASMA = 0;
        const int PERSONAGEM_TIPO_PACMAN = 1;

        const int PONTOS_MEDALHA_OURO = 1000;
        const int PONTOS_MEDALHA_PRATA = 500;
        const int PONTOS_MEDALHA_BRONZE = 150;
        const int PONTOS_PECA = 30;

        const int NUM_ITENS = 30; // Deve ser >=3
        const int NUM_FANTASMAS = 4;

        int[,] tabuleiro = new int[TAB_LINHAS_DEFAULT, TAB_COLUNAS_DEFAULT];
        Random rnd = new Random();

        public struct Item
        {
            public int tipo;
            public int pos_lin;
            public int pos_col;
            public bool ativo;
            public int pontos;
        }

        public Item[] itens;

        public struct Personagem
        {
            public int tipo;
            public int pos_lin;
            public int pos_col;
            public bool imune;
            public bool vivo;
        }

        public Personagem[] personagens;

        //TECLA DIGITADA
        int tecla=0;
        int contPontos;

        //STATUS DO GAME
        // 0 - off
        // 1 - on
        int statusGame = 0;

        public int mover(int status, int tecla)
        {
            return tecla;
        }

        private bool verificaPosicaoItem(int lin, int col)
        {
            /* Retorna TRUE se não há nenhum item na posição indicada */
            int c1;

            for (c1 = 0; c1 < NUM_ITENS; c1++)
            {
                if ((itens[c1].pos_lin == lin) && (itens[c1].pos_col == col))
                {
                    return false;
                }
            }
            return true;
        }

        public void inicializaTabuleiro()
        {
            for (int lin = 0; lin < TAB_LINHAS; lin++)
                for (int col = 0; col < TAB_COLUNAS; col++)
                {
                    tabuleiro[lin, col] = 0;
                    int vl = rnd.Next(0, 100);
                    if (vl > 90)
                        tabuleiro[lin, col] = CASA_TIPO_OBSTACULO;
                    if (vl < 20)
                        tabuleiro[lin, col] = CASA_TIPO_DESCANSO;
                }
            contPontos = 0;
            lblMensagem.Text = "PONTOS: " + contPontos.ToString();
        }

        public void inicializaItens()
        {
            int c1;
            int candidato_linha;
            int candidato_coluna;
            
            itens = new Item[NUM_ITENS];

            itens[0].tipo = ITEM_TIPO_MEDALHA_OURO;
            itens[0].pontos = PONTOS_MEDALHA_OURO;
            
            itens[1].tipo = ITEM_TIPO_MEDALHA_PRATA;
            itens[1].pontos = PONTOS_MEDALHA_PRATA;
            
            itens[2].tipo = ITEM_TIPO_MEDALHA_BRONZE;
            itens[2].pontos = PONTOS_MEDALHA_BRONZE;

            for (c1 = 3; c1 < NUM_ITENS; c1++)
            {
                itens[c1].tipo = ITEM_TIPO_PECA;
                itens[c1].pontos = PONTOS_PECA;
            }

            for (c1=0;c1<NUM_ITENS; c1++)
            {
                itens[c1].ativo = true;
            }

            for (c1 = 0; c1 < NUM_ITENS; c1++)
            {
                while (true)
                {
                    candidato_linha = rnd.Next(0, TAB_LINHAS - 1);
                    candidato_coluna = rnd.Next(0, TAB_COLUNAS - 1);

                    if (tabuleiro[candidato_linha, candidato_coluna] == CASA_TIPO_OBSTACULO)
                    {
                        continue;
                    }

                    if (verificaPosicaoItem(candidato_linha, candidato_coluna))
                    {
                        itens[c1].pos_lin = candidato_linha;
                        itens[c1].pos_col = candidato_coluna;
                        /*if (c1 == 0)
                        {
                            Console.Write("Ouro: " + Convert.ToString(candidato_linha) + ", " + Convert.ToString(candidato_coluna)+"\n");
                        }
                        else if (c1 == 1)
                        {
                            Console.Write("Prata: " + Convert.ToString(candidato_linha) + ", " + Convert.ToString(candidato_coluna) + "\n");
                        }
                        else if (c1==2)
                        {
                            Console.Write("Bronze: " + Convert.ToString(candidato_linha) + ", " + Convert.ToString(candidato_coluna) + "\n");
                        }
                        else
                        {
                            Console.Write("Item: " + Convert.ToString(candidato_linha) + ", " + Convert.ToString(candidato_coluna) + "\n");
                        }*/
                        break;
                    }
                }
            }

        }

        public void inicializaPersonagens()
        {
            int c1, c2;
            int candidato_linha;
            int candidato_coluna;
            bool flag_conflito;
            
            personagens = new Personagem[NUM_FANTASMAS + 1];

            personagens[0].tipo = PERSONAGEM_TIPO_PACMAN;
            personagens[0].imune = false;
            personagens[0].vivo = true;

            for (c1 = 1; c1 <= NUM_FANTASMAS; c1++)
            {
                personagens[c1].tipo = PERSONAGEM_TIPO_FANTASMA;
                personagens[c1].imune = true;
                personagens[c1].vivo = true;
            }

            for(c1 = 0; c1<(NUM_FANTASMAS+1); c1++)
            {
                while (true)
                {
                    candidato_linha = rnd.Next(0, TAB_LINHAS - 1);
                    candidato_coluna = rnd.Next(0, TAB_COLUNAS - 1);
                    flag_conflito = false;

                    if (tabuleiro[candidato_linha, candidato_coluna] == CASA_TIPO_OBSTACULO)
                    {
                        continue;
                    }

                    if (c1 > 0)
                    {
                        for (c2 = 0; c2 < c1; c2++)
                        {
                            if ((personagens[c2].pos_lin == candidato_linha)&&
                                (personagens[c2].pos_col == candidato_coluna))
                            {
                                flag_conflito = true;
                                break;
                            }
                        }
                        if (flag_conflito)
                        {
                            continue;
                        }
                        else
                        {
                            personagens[c1].pos_lin = candidato_linha;
                            personagens[c1].pos_col = candidato_coluna;
                            break;
                        }
                    }
                    else
                    {
                        personagens[c1].pos_lin = candidato_linha;
                        personagens[c1].pos_col = candidato_coluna;
                        /*if (c1 == 0)
                        {
                            Console.Write("Pacman: "+Convert.ToString(candidato_linha)+", "+Convert.ToString(candidato_coluna)+"\n");
                        }
                        else
                        {
                            Console.Write("Fantasma: " + Convert.ToString(candidato_linha) + ", " + Convert.ToString(candidato_coluna)+"\n");
                        }*/
                        break;
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            inicializaTabuleiro();
            inicializaItens();
            inicializaPersonagens();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int c1;
            Point[] pts;
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 1);
            Pen BluePen = new Pen(Color.Blue, 1);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            SolidBrush WhiteBrush = new SolidBrush(Color.White);
            SolidBrush GreenBrush = new SolidBrush(Color.Green);
            SolidBrush YellowBrush = new SolidBrush(Color.Yellow);
            SolidBrush GrayBrush = new SolidBrush(Color.Gray);
            SolidBrush BrownBrush = new SolidBrush(Color.Brown);
            SolidBrush MagentaBrush = new SolidBrush(Color.Magenta);
            SolidBrush RedBrush = new SolidBrush(Color.Red);

            for (int lin = 0; lin < TAB_LINHAS; lin++)
                for (int col = 0; col < TAB_COLUNAS; col++)
                {
                    if (tabuleiro[lin, col] == CASA_TIPO_NORMAL)
                    {
                        e.Graphics.FillRectangle(WhiteBrush, 
                                                 col * 20, 
                                                 lin * 20, 
                                                 (col + 1) * 20, 
                                                 (lin + 1) * 20);
                        
                        e.Graphics.DrawRectangle(blackPen, 
                                                 col*20, 
                                                 lin*20, 
                                                 (col+1)*20, 
                                                 (lin+1)*20);
                    }
                    else
                    if(tabuleiro[lin, col] == CASA_TIPO_OBSTACULO)
                    {
                        e.Graphics.FillRectangle(BlueBrush, col * 20, lin * 20, (col + 1) * 20, (lin + 1) * 20);
                        e.Graphics.DrawRectangle(blackPen, col * 20, lin * 20, (col + 1) * 20, (lin + 1) * 20);
                    }
                    else
                    if (tabuleiro[lin, col] == CASA_TIPO_DESCANSO)
                    {
                        e.Graphics.FillRectangle(GreenBrush, col * 20, lin * 20, (col + 1) * 20, (lin + 1) * 20);
                        e.Graphics.DrawRectangle(blackPen, col * 20, lin * 20, (col + 1) * 20, (lin + 1) * 20);
                    }
                }

            for (c1=0; c1 < NUM_ITENS; c1++)
            {
                switch (itens[c1].tipo)
                {
                    case ITEM_TIPO_MEDALHA_OURO:
                        e.Graphics.FillEllipse(YellowBrush, 
                            new Rectangle(itens[c1].pos_col * 20, 
                                          itens[c1].pos_lin * 20, 
                                          20, 
                                          20));
                        break;
                    case ITEM_TIPO_MEDALHA_PRATA:
                        e.Graphics.FillEllipse(GrayBrush,
                            new Rectangle(itens[c1].pos_col * 20,
                                          itens[c1].pos_lin * 20,
                                          20,
                                          20));
                        break;
                    case ITEM_TIPO_MEDALHA_BRONZE:
                        e.Graphics.FillEllipse(BrownBrush,
                            new Rectangle(itens[c1].pos_col * 20,
                                          itens[c1].pos_lin * 20,
                                          20,
                                          20));
                        break;
                    case ITEM_TIPO_PECA:
                        e.Graphics.FillEllipse(MagentaBrush,
                            new Rectangle(itens[c1].pos_col * 20,
                                          itens[c1].pos_lin * 20,
                                          20,
                                          20));
                        break;
                }
            }
            
            for (c1 = 0; c1 < (NUM_FANTASMAS + 1); c1++)
            {
                if (personagens[c1].tipo == PERSONAGEM_TIPO_PACMAN)
                {
                    e.Graphics.FillPie(YellowBrush,
                                       new Rectangle(personagens[c1].pos_col * 20,
                                          personagens[c1].pos_lin * 20,
                                          20,
                                          20),
                                          20,
                                          320);
                    e.Graphics.DrawPie(blackPen,
                                       new Rectangle(personagens[c1].pos_col * 20,
                                          personagens[c1].pos_lin * 20,
                                          20,
                                          20),
                                          20,
                                          320);
                }
                if (personagens[c1].tipo == PERSONAGEM_TIPO_FANTASMA)
                {
                    pts = new Point[3];
                    pts[0].X = personagens[c1].pos_col * 20;
                    pts[0].Y = personagens[c1].pos_lin * 20 + 20;

                    pts[1].X = personagens[c1].pos_col * 20 + 20;
                    pts[1].Y = personagens[c1].pos_lin * 20 + 20;

                    pts[2].X = personagens[c1].pos_col * 20 + 10;
                    pts[2].Y = personagens[c1].pos_lin * 20;

                    e.Graphics.FillPolygon(RedBrush, pts);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tecla=mover(statusGame ,tecla);

            pictureBox1.Invalidate();
        }

        private void txbTeclas_KeyDown(object sender, KeyEventArgs e)
        {
            tecla = e.KeyValue;
            tecla=mover(statusGame,tecla);
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            inicializaTabuleiro();
            inicializaItens();
            inicializaPersonagens();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int c1, c2;
            
            String[] con = new String[TAB_LINHAS];
            for (c1 = 0; c1 < TAB_LINHAS; c1++)
            {
                for (c2 = 0; c2 < TAB_COLUNAS; c2++) { 
                    con[c1] = con[c1] + Convert.ToString(tabuleiro[c1, c2]) + " ";
                }
            }

            File.WriteAllLines(".\\mapa.pacman", con);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int c1, c2;
            String[] con = File.ReadAllLines(".\\mapa.pacman");
            String[] lin;

            string aux = con[0];
            lin = aux.Split(' ');

            TAB_LINHAS = con.Length;
            TAB_COLUNAS = lin.Length-1;

            tabuleiro = new int[TAB_LINHAS, TAB_COLUNAS];

            for (c1 = 0; c1 < TAB_LINHAS; c1++)
            {
                aux = con[c1];
                lin = aux.Split(' ');

                for (c2 = 0; c2 < TAB_COLUNAS; c2++)
                {
                    Console.WriteLine(lin[c2].TrimEnd('\n'));
                    tabuleiro[c1,c2] = Convert.ToInt32(lin[c2]);
                }
            }
            inicializaItens();
            inicializaPersonagens();
        }
    }
}
