using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();

            while (CadastroUsuarios.UsuarioLogado == null)
            {
                Visible = false;
                f.ShowDialog();
                
                if (FormLogin.Cancelar == true)
                {
                    Application.Exit();
                    return;
                }
            }
            Visible = true;
        }

        private void btnPedra_Click(object sender, EventArgs e)
        {
            StartGame(0);
        }

        private void btnPapel_Click(object sender, EventArgs e)
        {
            StartGame(2);
        }

        private void btnTesoura_Click(object sender, EventArgs e)
        {
            StartGame(1);
        }

        private void StartGame (int opcao)
        {
            labelResultado.Visible = false;
            Game jogo = new Game();
            
            switch (jogo.Jogar(opcao))
            {
                case Game.Resultado.Ganhar:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Ganhar.png");
                    goto default;

                case Game.Resultado.Empatar:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Empatar.png");
                    goto default;

                case Game.Resultado.Perder:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Perder.png");
                    goto default;

                default:
                    pictureBox1.Image = jogo.ImgJogador;
                    pictureBox2.Image = jogo.ImgPC;
                    break;
              
            }
        }
     
    }
}
