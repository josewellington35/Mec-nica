using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mecânica
{
    public partial class Guincho : Form
    {
        Ordem_de_Serviço i = new Ordem_de_Serviço();
        double distancia = 0, result = 0;
        public Guincho()
        {
            InitializeComponent();
        }
      

        public void button1_Click(object sender, EventArgs e)
        {
           

            distancia = Convert.ToDouble(txtDistancia.Text);
            //tempo = Convert.ToDouble(txtTempo.Text);
            distancia = distancia * 1000;
            if (distancia <= 2000) { MessageBox.Show("Guincho GRATIS"); } else { }
            if (distancia > 2000) { result = 50; }
            if (distancia > 5000) { result = 80; }
            if (distancia > 10000) { result = 100; }
            if (distancia >= 20000) { result = 140; }
            if (distancia >= 30000) { result = 180; } else { if (distancia > 40000) { result = 200; } }
            if (distancia >= 50000) { result = 220; }
            if (distancia > 50000) { MessageBox.Show("Não tem serviço para essa distancia "); Close(); }
         
            i.txtPecas.Text = Convert.ToString(result); 

            lblresult.Text = result.ToString();
         
            
        }
      
        

        

        private void Guincho_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            i.ShowDialog();
            
        }

        private void txtDistancia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
