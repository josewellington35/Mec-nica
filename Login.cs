using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace mecânica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Controle controle = new Controle();
            controle.Acessar(txtLogin.Text, txtSenha.Text);
            if (controle.tem)
            {
                MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Principal principal = new Principal();
                principal.ShowDialog();

            }
            else
            {
                MessageBox.Show("Login não encontrado, verifique login e senha", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { txtSenha.UseSystemPasswordChar = true; }
            else { txtSenha.UseSystemPasswordChar = false; }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal P = new Principal();
            P.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.Acessar(txtLogin.Text, txtSenha.Text);
            if (controle.tem)
            {
                MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Principal principal = new Principal();
                principal.ShowDialog();

            }
            else
            {
                MessageBox.Show("Login não encontrado, verifique login e senha", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_MouseClick(object sender, MouseEventArgs e)
        {

           // txtSenha.UseSystemPasswordChar = true;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //txtSenha.UseSystemPasswordChar = true;

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Pesquisa_de_Clientes o = new Pesquisa_de_Clientes();
            o.ShowDialog();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

            Agenda o = new Agenda();
            o.ShowDialog();
        }
    }
}
