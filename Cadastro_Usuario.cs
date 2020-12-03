using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mecânica
{
    public partial class Cadastro_Usuario : Form
    {
        public Cadastro_Usuario()
        {
            InitializeComponent();
        }

        private void Cadastro_Usuario_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if ((txtLogin.Text == "") || (txtSenha.Text == "") || (txtConfSenha.Text == ""))

            {
                MessageBox.Show("todos os campos são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Controle controle = new Controle();
                String mensagem = controle.cadastrar(txtLogin.Text, txtSenha.Text, txtConfSenha.Text);
                if (controle.tem)
                {
                    MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(controle.messagem);
                }
                Close();
            }
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
