using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mecânica
{
    class clnAgenda
    {

        ClnBancodados ObjBancoDados = new ClnBancodados();
        string comando;
        string AG;
        private string COD_Agenda, nome, tel, CPF, Hora, Data,Vaga,Vaga2,Vaga3;

       
        public string Nome { get => nome; set => nome = value; }
        public string Tel { get => tel; set => tel = value; }
        public string CPF1 { get => CPF; set => CPF = value; }
        public string Hora1 { get => Hora; set => Hora = value; }
        public string Data1 { get => Data; set => Data = value; }
        public string COD_Agenda1 { get => COD_Agenda; set => COD_Agenda = value; }
        public string Vaga1 { get => Vaga; set => Vaga = value; }
       

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "select COD_Agenda, Nome,Tel,CPF,data,Hora,Box  from   Agenda Where Nome like '%" + strDescicao + "%' and Ativo = '1' order by COD_Agenda";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string COD_Agenda)
        {
            comando = "select * from  Agenda where  COD_Agenda  ='" + COD_Agenda + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO  Agenda ";
            comando += ("VALUES(");
            comando += ("'" + Nome + "',");
            comando += ("'" + Tel + "',");
             comando += ("'" + CPF1 + "',");
            comando += ("'" + Hora + "',");
            comando += ("'" + Data1 + "',");
            comando += ("'" + Vaga + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);


        }
        public void Alterar()
        {

            comando = ("UPDATE   Agenda ");
            comando += ("SET ");
            comando += ("Nome = '" + Nome + "',");
            comando += ("Tel = '" + Tel + "',");
            comando += ("CPF = '" + CPF1 + "',");
            comando += ("Hora = '" + Hora1 + "',");
            comando += ("Data = '" + Data1 + "',");
            comando += ("Vaga = '" + Vaga1 + "',");
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_CLIENTE = ' " + COD_Agenda1 + "'");
            ObjBancoDados.ExecutaComando(comando);

        }



        internal bool jaPossuiAgendamento()
        {
          //AG = " select * from Agenda where Hora = '"+ Hora1 + "'" and data ="'" + Data1 + " and vaga1 = '"+ Vaga1 + "'";
            AG = "select * from Agenda where Hora ='" + Hora1 + "' and data ='" +Data1+ "' and Box ='"  + Vaga1 +"'";
            return (ObjBancoDados.RetornaTabela(AG).Rows.Count > 0);
        }

        public void ExcluirLogicamente()
        {
            comando = ("UPDATE   Agenda ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + "'");
            comando += ("WHERE ");
            comando += ("COD_Agenda = '" + COD_Agenda1 + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}
