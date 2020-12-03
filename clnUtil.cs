using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace mecânica
{
    class clnUtil
    {
        string comando = "";
        ClnBancodados ObjbancoDados = new ClnBancodados();

        public DataTable PreencherUF()
        {
            comando = "Select UF from t_UF";
            return ObjbancoDados.RetornaTabela(comando);
        }

        public SqlDataReader ProcuraCep(string cep)
        {
            comando = "select * from CepFiltradas$ where CEP ='" + cep + "'";
            return ObjbancoDados.RetornaLinha(comando);
        }
        public DataTable PreencherCargo()
        {

            comando = "Select TIPO from CARGO";
            return ObjbancoDados.RetornaTabela(comando);



        }
        public SqlDataReader PreencherEscolaridade()
        {

            comando = "Select TIPO from Escolaridadecb";
            return ObjbancoDados.RetornaLinha(comando);



        }
        public DataTable PreencherFornecedor()
        {
            //Envia a consulta por parâmetro para objeto e aguarda o retorno
            comando = "select nome from Fornecedor WHERE Ativo = 1";
            return ObjbancoDados.RetornaTabela(comando);
        }

        public DataTable PreencherMarca()
        {
            //Envia a consulta por parâmetro para objeto e aguarda o retorno
            comando = "select marca from Plan4$ GROUP by marca";
            return ObjbancoDados.RetornaTabela(comando);
        }

        //Select modelo From Plan4$ where marca='audi'
        public DataTable PreencherModelo(string valor)
        {
            //Envia a consulta por parâmetro para objeto e aguarda o retorno
            comando = "Select modelo From Plan4$ where marca='" + valor + "'";
            return ObjbancoDados.RetornaTabela(comando);
        }


    }
}
