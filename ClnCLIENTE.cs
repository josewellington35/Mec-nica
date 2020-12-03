
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mecânica
{
    class ClnCLIENTE
    {
        string comando;
        ClnBancodados ObjBancoDados = new ClnBancodados();
        private string COD_CLIENTE, _nome, _tel, _cep, _endereco, _UF, _nr, _bairro, _cidade, DT_NASC,CPF,Email,Genero;
      
      
        public string Nome { get => _nome; set => _nome = value; }
        public string Tel { get => _tel; set => _tel = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public string UF { get => _UF; set => _UF = value; }
        public string Nr { get => _nr; set => _nr = value; }
        public string Bairro { get => _bairro; set => _bairro = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }
       
        public string COD_CLIENTE1 { get => COD_CLIENTE; set => COD_CLIENTE = value; }
        public string DT_NASC1 { get => DT_NASC; set => DT_NASC = value; }
   
        public string Email1 { get => Email; set => Email = value; }
        public string CPF1 { get => CPF; set => CPF = value; }
        public string Genero1 { get => Genero; set => Genero = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "select COD_CLIENTE, Nome,Tel,CPF from   CLIENTEr Where Nome like '%" + strDescicao + "%' and Ativo = '1' order by COD_CLIENTE";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string COD_CLIENTE)
        {
            comando = "select * from  CLIENTEr where  COD_CLIENTE  ='" + COD_CLIENTE + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO  CLIENTEr ";
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
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void Alterar()
        {

            comando  = ("UPDATE   CLIENTEr ");
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
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("COD_CLIENTE = ' " + COD_CLIENTE + "'");
            ObjBancoDados.ExecutaComando(comando);

        }
        public void ExcluirLogicamente()
        {
            comando  = ("UPDATE   CLIENTEr ");
            comando += ("SET ");
            comando += ("Ativo = '"+0+"'"); 
            comando += ("WHERE ");
            comando += ("COD_CLIENTE = '" + COD_CLIENTE + "'");
            ObjBancoDados.ExecutaComando(comando);
        }

        
        }
    }

