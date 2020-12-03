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
    public partial class Funcionario : Form
    {
        string mensagem = "";
        public Funcionario()
        {
            InitializeComponent();
        }
        clnFuncionario ObjClnMecanica = new clnFuncionario();
        clnUtil objClnUtil = new clnUtil();
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Funcionario_Load(object sender, EventArgs e)
        {
            //cboCargo.Items.Add("Mecânico ");
            //cboCargo.Items.Add("Atendente ");
            cboCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherUF();
            cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherCargo();



            txtCod.Enabled = false;
         
            txtNome.Focus();



            txtNome.Focus();
            if (txtCod.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnMecanica.LocalizarCodigo(txtCod.Text);
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
                    txtDT_NASC.Text = ObjDrDados["DT_NASC"].ToString();
                    txtCPF.Text = ObjDrDados["CPF"].ToString();
                    txtEmail.Text = ObjDrDados["Email"].ToString();

                    //  Para selecionar:
                    if (ObjDrDados["Genero"].ToString() == "F")
                    {
                        rdbFeminino.Select();
                    }
                    else
                    {
                        rdbMasculino.Select();
                    }
                }
                txtNome.Focus();
            }
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
         
        public void PreencherUF()
        {
            cboUF.DataSource = objClnUtil.PreencherUF();
            cboUF.ValueMember = "UF";
            cboUF.DisplayMember = "UF";
            cboUF.SelectedIndex = 23;
        }

        public void PreencherCargo()
        {
            cboCargo.DataSource = objClnUtil.PreencherCargo();
            cboCargo.ValueMember = "TIPO";
            cboCargo.DisplayMember = "TIPO";
            cboCargo.SelectedIndex = 1;
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (txtTel.Text == "") || (txtNr.Text == "") || (txtMaskCep.Text == "") ||
               (txtCPF.Text == "") || (cboUF.Text == "") || (txtBairro.Text == "") || (txtCidade.Text == "") || (txtDT_NASC.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ObjClnMecanica.Nome = txtNome.Text;
                ObjClnMecanica.Tel = txtTel.Text;
                ObjClnMecanica.Endereco = txtEnd.Text;
                ObjClnMecanica.Nr = txtNr.Text;
                ObjClnMecanica.DT_NASC1 = txtDT_NASC.Text;
                ObjClnMecanica.CPF1 = txtCPF.Text;
                ObjClnMecanica.Email1 = txtEmail.Text;
                ObjClnMecanica.Bairro = txtBairro.Text;
                ObjClnMecanica.Cidade = txtCidade.Text;
                ObjClnMecanica.Cep = txtMaskCep.Text.Replace("-", "");
                ObjClnMecanica.UF = cboUF.Text;
                ObjClnMecanica.Cargo1 = cboCargo.Text;
                if (rdbFeminino.Checked)
                {
                    ObjClnMecanica.Genero1 = rdbFeminino.Text;
                }
                else
                {
                    ObjClnMecanica.Genero1 = rdbMasculino.Text;
                }




                //preencher cod cliente
                if (txtCod.Text == "")
                {
                    ObjClnMecanica.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtCod.Text != "")
                {
                    ObjClnMecanica.COD_FUNCIONARIO1 = txtCod.Text;
                    ObjClnMecanica.Alterar();
                    MessageBox.Show("Registro Número " + txtCod.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();
                  
               

            }
        }

        private void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void rdbFeminino_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFeminino.Checked)
            {
                rdbFeminino.Select();
            }
            else { rdbMasculino.Select(); }
        }

        private void rdbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMasculino.Checked)
            {
                rdbMasculino.Select();

            }
            else { rdbFeminino.Select(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastro_Usuario c = new Cadastro_Usuario();
            c.ShowDialog();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Vemail.validarEmail(txtEmail.Text))
            {
                txtEmail.BackColor = Color.White;
               // MessageBox.Show("E-MAIL INFORMADO É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtEmail.BackColor = Color.Red;
                MessageBox.Show("E-MAIL INFORMADO É INVÁLIDO! POR FAVOR, VERIFIQUE SE DIGITOU CORRETAMENTE E TENTE NOVAMENTE!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            txtTel.MaxLength = 11;
        }

        private void txtDT_NASC_TextChanged(object sender, EventArgs e)
        {
            txtDT_NASC.MaxLength = 10;
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtCPF.MaxLength = 11;
        }

        private void txtNr_TextChanged(object sender, EventArgs e)
        {
            txtNr.MaxLength = 11;
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtCPF.MaxLength = 11;
            txtCPF.MaskInputRejected += new MaskInputRejectedEventHandler(txtCPF_MaskInputRejected);
            txtCPF.Mask = "000,000,000-00";
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string valor = txtCPF.Text;
            if (ValidaCPF.IsCpf(txtCPF.Text))
            {
                txtCPF.BackColor = Color.White;
                mensagem = "O número é um CPF Válido !";
            }
            else
            {
                txtCPF.BackColor = Color.Red;
                mensagem = "O número é um CPF Inválido !";
            }
            MessageBox.Show(mensagem, "Validação");


        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8))
            {
                e.Handled = false; //Permite
            }
            else
            {
                e.Handled = true; //Não permite
            }
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

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
