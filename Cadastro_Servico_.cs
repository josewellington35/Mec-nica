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
    public partial class Cadastro_Servico_ : Form
    {
        clnMaoObra ObjClnMecanica = new clnMaoObra();
        public Cadastro_Servico_()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (txtValor.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ObjClnMecanica.Servico = txtNome.Text;
                ObjClnMecanica.Valor = txtValor.Text;





                //preencher cod cliente
                if (txtCod.Text == "")
                {
                    ObjClnMecanica.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtCod.Text != "")
                {
                    ObjClnMecanica.COD_MaoObra1 = txtCod.Text;
                    ObjClnMecanica.Alterar();
                    MessageBox.Show("Registro Número " + txtCod.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();
            }
        }

        private void Cadastro_Servico__Load(object sender, EventArgs e)
        {
            txtCod.Enabled = false;
        }
    }
}
