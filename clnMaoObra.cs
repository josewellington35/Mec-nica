using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class clnMaoObra
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string COD_MaoObra, servico, valor;

        public string COD_MaoObra1 { get => COD_MaoObra; set => COD_MaoObra = value; }
        public string Servico { get => servico; set => servico = value; }
        public string Valor { get => valor; set => valor = value; }
 
        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "select COD_MaoObra, Servico,Valor from MaoObra Where Servico like '%" + strDescicao + "%' and Ativo = '1' order by COD_MaoObra";
            return ObjBancoDados.RetornaTabela(comando);
           
           
        }
        public SqlDataReader LocalizarCodigo(string COD_MaoObra)
        {
            comando = "select * from  MaoObra where  COD_MaoObra  ='" + COD_MaoObra + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO  MaoObra ";
            comando += ("VALUES(");
            comando += ("'" + Servico + "',");
            comando += ("'" + Valor + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void Alterar()
        {

            comando = ("UPDATE   MaoObra ");
            comando += ("SET ");
            comando += ("Servico = '" + Servico + "',");
            comando += ("Valor = '" + Valor + "',");
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_MaoObra = ' " + COD_MaoObra + "'");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE   MaoObra ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + "'");
            comando += ("WHERE ");
            comando += ("COD_MaoObra = '" + COD_MaoObra + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}
