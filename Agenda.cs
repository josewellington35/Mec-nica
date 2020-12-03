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
using System.Windows.Controls;

namespace mecânica
{
    public partial class Agenda : Form
    {
        string mensagem = "";
        clnAgenda objAgenda = new clnAgenda();
        HoraAgenda objHoraAgenda = new HoraAgenda();
        public Agenda()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {


        }

        private void AplicarBlackKourRanges(DatePicker control)
        {

        }
            

        private void Agenda_Load(object sender, EventArgs e)
        {
           
            cboHora.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherHora();
            txtNome.Focus();
            txtCod.Enabled = false;
           
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
         
            dgv.RowHeadersVisible = false;

        }

        private void cboHora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void PreencherHora()
        {
            cboHora.DataSource = objHoraAgenda.PreencherHora();
            cboHora.ValueMember = "Hora";
            cboHora.DisplayMember = "Hora";
            cboHora.SelectedIndex = 4;
        }

        private void btnSalvarOS_Click(object sender, EventArgs e)
        {
            clnAgenda age = new clnAgenda();
            
            if ((txtNome.Text == "") || (txtTel.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objAgenda.Nome = txtNome.Text;
                objAgenda.Tel = txtTel.Text;
                objAgenda.CPF1 = txtCPF.Text;
                objAgenda.Hora1 = cboHora.Text;
                objAgenda.Data1 = dateTimePicker1.Text;
                objAgenda.Vaga1 = cbovaga.Text;
                //  string agenda;
                

                // agenda = "select * from Agenda where Hora=" + cboHora.Text + " and data=" + dateTimePicker1.Text + " and vaga1=" + cbovaga.Text;
              
                if (objAgenda.jaPossuiAgendamento())
                {

                   
                    MessageBox.Show(" Angendamento não pode ser efetuado por conta da disponibilidade", "Indisponivel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objAgenda.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //try
                //{
                //}
                //catch (SqlException ex)
                //{
                //    if (ex.Number != 2627)
                //    {
                //        objAgenda.Gravar();
                //        MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("erro");
                //    }

                //}

                //if (txtCod.Text == "")
                //{




                //}
                //else if (txtCod.Text != "")
                //{
                //    objAgenda.COD_Agenda1 = txtCod.Text;
                //    objAgenda.Alterar();
                //    MessageBox.Show("Registro Número " + txtCod.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                txtCPF.Text = "";
                txtNome.Text = "";
                txtTel.Text = "";
                this.Close();
             
            }
          
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CarregarDataGrid();
        }
        public void CarregarDataGrid()
        {
            dgv.DataSource = objAgenda.LocalizarPorNome(txtNome.Text);
            dgv.Columns[0].HeaderText = ("CÓDIGO");
            dgv.AutoResizeColumns();


            if (dgv.RowCount == 0)
            {

                btnExcluir.Enabled = false;

                MessageBox.Show("NÃO FORAM ENCONTRADOS DADOS COM A INFORMÇÃO" + txtNome.Text, "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv.DataSource = null;
                txtNome.Text = "";
                txtNome.Focus();
            }
            else
            {

                btnExcluir.Enabled = true;

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir o registro: " + Convert.ToString(dgv.CurrentRow.Cells[0].Value + "?"),
                    "E X C L U S Ã O", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == resultado)
                {
                    objAgenda.COD_Agenda1 = dgv.CurrentRow.Cells[0].Value.ToString();
                    objAgenda.ExcluirLogicamente();
                    MessageBox.Show("Registro excuido com sucesso", "E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operação cancelada ", "cancelamento E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CarregarDataGrid();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtCPF.MaxLength = 11;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agenda ObjClientt = new Agenda();
            ObjClientt.Text = ">>> ALTERAR <<<";
            ObjClientt.txtCod.Enabled = false;
            ObjClientt.btnAgendar.Text = "&Alterar";
            ObjClientt.txtCod.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            ObjClientt.txtNome.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            ObjClientt.txtTel.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            ObjClientt.txtCPF.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            ObjClientt.cboHora.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            ObjClientt.dateTimePicker1. Focus();
            ObjClientt.cbovaga.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);

            ObjClientt.txtNome.Focus();
            ObjClientt.txtTel.Focus();
            ObjClientt.txtCPF.Focus();
            ObjClientt.cboHora.Focus();
            ObjClientt.dateTimePicker1.Focus();
            ObjClientt.cbovaga.Focus();

            //btnAlterar.Visible = false;
            //button1.Visible = false;
            //btnExcluir.Visible = false;
            //dgv.RowHeadersVisible = false;
            ObjClientt.Show();
            CarregarDataGrid();
            this.Close();
          
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            txtTel.MaxLength = 14;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
               
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

         
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
            
                
               
               
              //  else { radioButton1.Select(); }
                
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAlterar.Enabled = true;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
