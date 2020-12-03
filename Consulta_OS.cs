using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace mecânica
{
    public partial class Consulta_OS : Form
    {
        public Consulta_OS()
        {
            InitializeComponent();
        }
        ClnConsulta_os ObjClnMecanica = new ClnConsulta_os();
        public string nome, CPF, codigo_os,hora,maoOBRA,Valor_maoObra, produto_P, valor_P, modelo, total, itendecp, dinheiro, debito, credito, lblAp;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            valor_P = "";
            produto_P = "";
            this.Close();
        }

        private void Consulta_OS_Load(object sender, EventArgs e)
        {

            if (txtCod.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnMecanica.LocalizarCodigo(txtCod.Text);
                if (ObjDrDados.Read())
                {
                    txtNome.Text = ObjDrDados["nome"].ToString();
                    txtTel.Text = ObjDrDados["tel"].ToString();

                    maskValor.Text = ObjDrDados["CPF"].ToString();
                   
                    //  Para selecionar:
                  
                }
                txtNome.Focus();
               
                //maskValor.MaxLength = 11;
                //maskValor.Text = "";
                //maskValor.Mask = "000,000,000-00";
                //maskValor.MaskInputRejected += new MaskInputRejectedEventHandler(maskValor_MaskInputRejected);
            }







            if (listBox1.Text == "") { rodape(); }

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void rodape()
        {
            List<string> lista = produto_P.Split(';').ToList();
            foreach (string value in lista)
            {
                listBox1.Items.Add(value);
            }

            listBox1.Items.Add("                                        ");
            listBox1.Items.Add("======================================");
            listBox1.Items.Add(" " + maoOBRA +":"+Valor_maoObra + " ");
            listBox1.Items.Add(" " +hora +" ");
            listBox1.Items.Add("Valor Total R$:                     " + total + "                    ");
   
        }



    }
}
