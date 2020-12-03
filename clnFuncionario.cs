using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace mecânica
{
    class clnFuncionario
    {

        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string COD_FUNCIONARIO, _nome, _tel, _cep, _endereco, _UF, _nr, _bairro, _cidade, DT_NASC, CPF, Email, Genero, Cargo, ESCOLARIDADE;




        public string Nome { get => _nome; set => _nome = value; }
        public string Tel { get => _tel; set => _tel = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public string UF { get => _UF; set => _UF = value; }
        public string Nr { get => _nr; set => _nr = value; }
        public string Bairro { get => _bairro; set => _bairro = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }

       
        public string DT_NASC1 { get => DT_NASC; set => DT_NASC = value; }

        public string Email1 { get => Email; set => Email = value; }
        public string CPF1 { get => CPF; set => CPF = value; }
        public string Genero1 { get => Genero; set => Genero = value; }
    
        public string ESCOLARIDADE1 { get => ESCOLARIDADE; set => ESCOLARIDADE = value; }
        public string COD_FUNCIONARIO1 { get => COD_FUNCIONARIO; set => COD_FUNCIONARIO = value; }
        public string Cargo1 { get => Cargo; set => Cargo = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "select COD_FUNCIONARIO, Nome,Tel,CPF from   FUNCIONARIO Where Nome like '%" + strDescicao + "%' and Ativo = '1' order by COD_FUNCIONARIO";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string COD_FUNCIONARIO)
        {
            comando = "select * from  FUNCIONARIO where  COD_FUNCIONARIO  ='" + COD_FUNCIONARIO + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO  FUNCIONARIO ";
            comando += ("VALUES(");
            comando += ("'" + Nome + "',");
            comando += ("'" + Tel + "',");
            comando += ("'" + Endereco + "',");
            comando += ("'" + Nr + "',");
            comando += ("'" + DT_NASC1 + "',");
            comando += ("'" + CPF1 + "',");
            comando += ("'" + Email1 + "',");
            comando += ("'" + Bairro + "',");
            comando += ("'" + Cidade + "',");
            comando += ("'" + Cep + "',");
            comando += ("'" + UF + "',");
            comando += ("'" + Genero1 + "',");
            comando += ("'" + Cargo1 + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void Alterar()
        {

            comando = ("UPDATE   FUNCIONARIO ");
            comando += ("SET ");
            comando += ("Nome = '" + Nome + "',");
            comando += ("Tel = '" + Tel + "',");
            comando += ("Endereco = '" + Endereco + "',");
            comando += ("Nr = '" + Nr + "',");
            comando += ("DT_NASC = '" + DT_NASC1 + "',");
            comando += ("CPF = '" + CPF1 + "',");
            comando += ("Email = '" + Email1 + "',");
            comando += ("Bairro = '" + Bairro + "',");
            comando += ("Cidade = '" + Cidade + "',");
            comando += ("Cep = '" + Cep + "',");
            comando += ("UF = '" + UF + "',");
            comando += ("Genero = '" + Genero1 + "',");
            comando += ("Cargo = '" + Cargo1 + "',");
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_FUNCIONARIO = ' " + COD_FUNCIONARIO1 + "'");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE   FUNCIONARIO ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + "'");
            comando += ("WHERE ");
            comando += ("COD_FUNCIONARIO = '" + COD_FUNCIONARIO1 + "'");
            ObjBancoDados.ExecutaComando(comando);
        }


    }
}

