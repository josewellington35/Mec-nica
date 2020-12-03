using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class ClnConsulta_os
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string cod_os, _nome, _tel, cpf, produto, total,Hora,maoOBRA, valor_maoobra;

        public string Cod_os { get => cod_os; set => cod_os = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Tel { get => _tel; set => _tel = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Produto { get => produto; set => produto = value; }
        public string Total { get => total; set => total = value; }
        public string Hora1 { get => Hora; set => Hora = value; }
        public string MaoOBRA { get => maoOBRA; set => maoOBRA = value; }

        public string Valor_maoobra { get => valor_maoobra; set => valor_maoobra = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "select cod_os,nome,tel,CPF,total,produto,Hora,Moabra,valor_maoobra from   os Where nome like '%" + strDescicao + "%' and Ativo = '1' order by cod_os";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string cod_os)
        {
            comando = "select * from  os where  cod_os  ='" + cod_os + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO  os ";
            comando += ("VALUES(");
            comando += ("'" + Nome + "',");
            comando += ("'" + Tel + "',");
            comando += ("'" + cpf + "',");
            comando += ("'" + produto + "',");
            comando += ("'" + total + "',");
            comando += ("'" + Hora + "',");
            comando += ("'" + maoOBRA + "',");
            comando += ("'" + valor_maoobra + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);

        }
     
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE   os ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + "'");
            comando += ("WHERE ");
            comando += ("cod_os = '" + cod_os + "'");
            ObjBancoDados.ExecutaComando(comando);
        }


    }
}




