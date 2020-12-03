using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class ClnEmpresa
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string COD_Empresa, _nome,_NomeFantasia,_CNPJ, _tel, _cep, _endereco, _UF, _nr, _bairro, _cidade;

        public string COD_Empresa1 { get => COD_Empresa; set => COD_Empresa = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string NomeFantasia { get => _NomeFantasia; set => _NomeFantasia = value; }
        public string CNPJ { get => _CNPJ; set => _CNPJ = value; }
        public string Tel { get => _tel; set => _tel = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public string UF { get => _UF; set => _UF = value; }
        public string Nr { get => _nr; set => _nr = value; }
        public string Bairro { get => _bairro; set => _bairro = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select cod, nome,tel from   Empresa  Where nome like '%" + strDescicao + "%' and Ativo='1' order by cod";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string cod)
        {
            comando = "select * from   Empresa where COD_ Empresa1 ='" + cod + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO Empresa ";
            comando += ("VALUES(");
            comando += ("'" + Nome + "',");
            comando += ("'" + Tel + "',");
            comando += ("'" + Endereco + "',");
            comando += ("'" + Nr + "',");
            comando += ("'" + Bairro + "',");
            comando += ("'" + CNPJ + "',");
            comando += ("'" + Cidade + "',");
            comando += ("'" + Cep + "',");
            comando += ("'" + UF + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Alterar()
        {

            comando = ("UPDATE Empresa  ");
            comando += ("SET ");
            comando += ("nome = '" + Nome + "',");
            comando += ("Tel = '" + Tel + "',");
            comando += ("endereco = '" + Endereco + "',");
            comando += ("nr = '" + Nr + "',");
            comando += ("bairro = '" + Bairro + "',");
            comando += ("CNPJ = '" + Bairro + "',");
            comando += ("cidade = '" + Cidade + "',");
            comando += ("cep = '" + Cep + "',");
            comando += ("UF = '" + UF + "',");
            comando += ("ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_Empresa = ' " + COD_Empresa1 + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE Empresa  ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + " ' ");
            comando += ("WHERE ");
            comando += ("COD_Empresa = ' " + COD_Empresa1 + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}

    

