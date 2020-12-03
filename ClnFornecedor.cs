using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class ClnFornecedor
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string COD_Fornecedor, _nome, _NomeFantasia, _CNPJ, _tel, _cep, _endereco, _UF, _nr, _bairro, _cidade, _Email, TIPO_produto;

        public string COD_Fornecedor1 { get => COD_Fornecedor; set => COD_Fornecedor = value; }
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
        public string Email { get => _Email; set => _Email = value; }
       
        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select COD_Fornecedor, nome,tel,Email from   Fornecedor  Where nome like '%" + strDescicao + "%' and Ativo='1' order by COD_Fornecedor";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string COD_Fornecedor)
        {
            comando = "select * from  Fornecedor where COD_Fornecedor ='" + COD_Fornecedor + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO Fornecedor ";
            comando += ("VALUES(");
            comando += ("'" + Nome + "',");
            comando += ("'" + Tel + "',");
            comando += ("'" + Endereco + "',");
            comando += ("'" + Nr + "',");
            comando += ("'" + CNPJ + "',"); 
            comando += ("'" + Email + "',");
            comando += ("'" + Bairro + "',");
            comando += ("'" + Cidade + "',");
            comando += ("'" + Cep + "',");
            comando += ("'" + UF + "',");
            
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Alterar()
        {

            comando = ("UPDATE Fornecedor ");
            comando += ("SET ");
            comando += ("nome = '" + Nome + "',");
            comando += ("Tel = '" + Tel + "',");
            comando += ("endereco = '" + Endereco + "',");
            comando += ("nr = '" + Nr + "',");
            comando += ("CNPJ = '" + CNPJ + "',");
            comando += ("Email = '" + Email + "',");
            comando += ("Bairro = '" + Bairro + "',");
            comando += ("cidade = '" + Cidade + "',");
            comando += ("cep = '" + Cep + "',");
            comando += ("UF = '" + UF + "',");
   
            comando += ("ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_Fornecedor = ' " + COD_Fornecedor + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE Fornecedor ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + " ' ");
            comando += ("WHERE ");
            comando += ("COD_Fornecedor = ' " + COD_Fornecedor + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}




