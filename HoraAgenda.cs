using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace mecânica
{
    class HoraAgenda
    {
        ClnBancodados ObjBancoDados = new ClnBancodados();
        string comando = "";
        public DataTable PreencherHora()
        {
            comando = "Select Hora from t_Hora";
            return ObjBancoDados.RetornaTabela(comando);
        }
    }
}
