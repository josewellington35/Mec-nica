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
    public partial class Fornecedor : Form
    {
        ClnFornecedor ObjClnMecanica = new ClnFornecedor();
        clnUtil objClnUtil = new clnUtil();
        public Fornecedor()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if ((txtNome.Text == "") || (txtTel.Text == "") || (txtNr.Text == "") || (txtMaskCep.Text == "") ||
              (txtEnd.Text == "") || (cboUF.Text == "") || (txtBairro.Text == "") || (txtCidade.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ObjClnMecanica.Nome = txtNome.Text;
                ObjClnMecanica.Tel = txtTel.Text;
                ObjClnMecanica.Endereco = txtEnd.Text;
                ObjClnMecanica.Nr = txtNr.Text;
                ObjClnMecanica.Cep = txtMaskCep.Text.Replace("-", "");
               
                ObjClnMecanica.UF = cboUF.Text;
          
                ObjClnMecanica.Bairro = txtBairro.Text;
               // ObjClnMecanica.CNPJ = maskedTextBox1.Text;
                ObjClnMecanica.Email = txtEmail.Text;
                ObjClnMecanica.Cidade = txtCidade.Text;
              
                if (txtCodFORNECEDOR.Text == ""|| (Vemail.validarEmail(txtEmail.Text)))
                {
                    ObjClnMecanica.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtCodFORNECEDOR.Text != "")
                {
                    ObjClnMecanica.COD_Fornecedor1 = txtCodFORNECEDOR.Text;
                    ObjClnMecanica.Alterar();
                    MessageBox.Show("Registro Número " + txtCodFORNECEDOR.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void txtMaskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlDataReader drDados;
                string cep = txtMaskCep.Text.Replace("-", "");
                drDados = objClnUtil.ProcuraCep(cep);
                if (drDados.Read())
                {
                    txtEnd.Text = Convert.ToString(drDados["descricao"]);
                    cboUF.Text = Convert.ToString(drDados["UF"]);
                    txtBairro.Text = Convert.ToString(drDados["Bairro"]);
                    txtCidade.Text = Convert.ToString(drDados["cidade"]);
                    txtNr.Focus();
                }

                else
                {
                    MessageBox.Show("Cep não encontrado" + txtMaskCep.Text, "Cep", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEnd.Text = "";
                    cboUF.Text = "";
                    cboUF.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";

                    txtMaskCep.Clear(); txtMaskCep.Focus();
                    txtMaskCep.Mask = "00000-999";
                    txtMaskCep.SelectionStart = 0;
                }
            }
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            txtCodFORNECEDOR.Enabled = false;

            cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherUF();
            txtNome.Focus();
            if (txtCodFORNECEDOR.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnMecanica.LocalizarCodigo(txtCodFORNECEDOR.Text);
                if (ObjDrDados.Read())
                {
                    txtNome.Text = ObjDrDados["nome"].ToString();
                    txtTel.Text = ObjDrDados["tel"].ToString();
                    txtMaskCep.Text = ObjDrDados["cep"].ToString();
                    txtEnd.Text = ObjDrDados["endereco"].ToString();
                    cboUF.Text = ObjDrDados["UF"].ToString();
                    txtNr.Text = ObjDrDados["Nr"].ToString();
                    txtBairro.Text = ObjDrDados["bairro"].ToString();
                    txtCidade.Text = ObjDrDados["cidade"].ToString();

                }
                txtNome.Focus();
            }
        }
        public void PreencherUF()
        {
            cboUF.DataSource = objClnUtil.PreencherUF();
            cboUF.ValueMember = "UF";
            cboUF.DisplayMember = "UF";
            cboUF.SelectedIndex = 23;
        }

        private void txtCodFORNECEDOR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {
           // maskedTextBox1.MaxLength = 20;
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            txtTel.MaxLength = 11;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Vemail.validarEmail(txtEmail.Text))
            {
                txtEmail.BackColor = Color.White;
                MessageBox.Show("E-MAIL INFORMADO É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtEmail.BackColor = Color.Red;
                MessageBox.Show("E-MAIL INFORMADO É INVÁLIDO! POR FAVOR, VERIFIQUE SE DIGITOU CORRETAMENTE E TENTE NOVAMENTE!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_DragLeave(object sender, EventArgs e)
        {
            
               
            
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            //if (ValidaCNPJ.isCNPJ(maskedTextBox1.Text))
            //{
            //   // maskedTextBox1.BackColor = Color.Red;
            //   // MessageBox.Show("SEU CNPJ É INVÁLIDO! POR FAVOR, VERIFIQUE SE DIGITOU CORRETAMENTE E TENTE NOVAMENTE!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //  //  maskedTextBox1.BackColor = Color.White;
            //  //  MessageBox.Show("SEU CNPJ É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //   // maskedTextBox1.BackColor = Color.Red;
            //   // MessageBox.Show("SEU CNPJ É INVÁLIDO! POR FAVOR, VERIFIQUE SE DIGITOU CORRETAMENTE E TENTE NOVAMENTE!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //  //  maskedTextBox1.BackColor = Color.White;
            //   // MessageBox.Show("SEU CNPJ É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }

        private void txtMaskCep_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {//Verificar se é tecla enter 
                SqlDataReader drDados; //Cria DataReader para guardar dados
                string cep = txtMaskCep.Text.Replace("-", "");//Retira -
                drDados = objClnUtil.ProcuraCep(cep);//Preenche DataReader com os dados encontrados na tabela cep
                if (drDados.Read()) //Existem informações?
                {//Caso verdade, preencha as informações
                    txtEnd.Text = Convert.ToString(drDados["descricao"]);
                    cboUF.Text = Convert.ToString(drDados["UF"]);
                    txtBairro.Text = Convert.ToString(drDados["Bairro"]);
                    txtCidade.Text = Convert.ToString(drDados["cidade"]);
                    txtNr.Focus();
                }
                else
                {//Não encontrou o Cep
                    MessageBox.Show("Cep não encontrado: " + txtMaskCep.Text, "Cep", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Limpar Campos:
                    txtEnd.Text = "";
                    cboUF.Text = "";
                    cboUF.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";

                    txtMaskCep.Clear(); txtMaskCep.Focus();
                    txtMaskCep.Mask = "00000-999";
                    txtMaskCep.SelectionStart = 0;// txtMaskCep.Text.Length;
                    //txtMaskCep.SelectAll();

                }
            }
        }
    }
}
    


