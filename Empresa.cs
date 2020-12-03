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
    public partial class Empresa : Form
    {
        ClnEmpresa ObjClnMecanica = new ClnEmpresa();
        clnUtil objClnUtil = new clnUtil();
        public Empresa()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
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
                ObjClnMecanica.Cep = txtMaskCep.Text.Replace("-", "");
                ObjClnMecanica.Endereco = txtEnd.Text;
                ObjClnMecanica.UF = cboUF.Text;
                ObjClnMecanica.Nr = txtNr.Text;
                ObjClnMecanica.CNPJ = txtCNPJ.Text;
                ObjClnMecanica.Bairro = txtBairro.Text;
                ObjClnMecanica.Cidade = txtCidade.Text;
                if (txtCodEmpresa.Text == "")
                {
                    ObjClnMecanica.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtCodEmpresa.Text != "")
                {
                    ObjClnMecanica.COD_Empresa1 = txtCodEmpresa.Text;
                    ObjClnMecanica.Alterar();
                    MessageBox.Show("Registro Número " + txtCodEmpresa.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();
            }

        }

        private void Empresa_Load(object sender, EventArgs e)
        {

            cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherUF();
            txtNome.Focus();
            if (txtCodEmpresa.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnMecanica.LocalizarCodigo(txtCodEmpresa.Text);
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
    

        private void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCodEmpresa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
