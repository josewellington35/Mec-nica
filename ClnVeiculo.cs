using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class ClnVeiculo
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string _Placa, _Marca,  _Cor, _Modelo, COD_CLIENTE, COD_VEICULO;

        public string Placa { get => _Placa; set => _Placa = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
              public string Cor { get => _Cor; set => _Cor = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string COD_CLIENTE1 { get => COD_CLIENTE; set => COD_CLIENTE = value; }
        public string COD_VEICULO1 { get => COD_VEICULO; set => COD_VEICULO = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select COD_VEICULO,Placa, Marca,Modelo,Cor,COD_CLIENTE from  [VEICULO] Where COD_CLIENTE like '%" + strDescicao + "%' and Ativo='1' order by COD_VEICULO";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string COD_VEICULO)
        {
            comando = "select * from  [ VEICULO] where [COD_VEICULO] ='" + COD_VEICULO + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO [VEICULO] ";
            comando += ("VALUES(");
            comando += ("'" + Placa + "',");
            comando += ("'" + Marca + "',");
            comando += ("'" + Cor + "',");
            comando += ("'" + Modelo + "',");
            comando += ("'" + COD_CLIENTE1 + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);



        }
        public void Alterar()
        {

            comando = ("UPDATE VEICULO ");
            comando += ("SET ");
            comando += ("Placa = '" + Placa + "',");
            comando += ("Marca = '" + Marca + "',");
            comando += ("Cor = '" + Cor + "',");
            comando += ("Modelo = '" + Modelo + "',");
            comando += ("COD_CLIENTE = '" + COD_CLIENTE1 + "',");

            comando += ("WHERE ");
            
            ObjBancoDados.ExecutaComando(comando);
        }
       
        public void ExcluirLogicamente()
        {
            comando  = ("UPDATE   VEICULO ");
            comando += ("SET ");
            comando += ("Ativo = '"+0+"'");
            comando += ("WHERE ");
            comando += ("COD_VEICULO = '" + COD_VEICULO + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}

    

