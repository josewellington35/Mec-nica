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
    class ClnBancodados
    {
        public static SqlConnection AbreBanco()
        {
            try
            {
               
                string Stringconexao = @"Data Source= LAPTOP-VDAM66LU\SQLEXPRESS;Initial Catalog=RESERVA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(Stringconexao);
                conn.Open();
                
                    return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FechaBanco(SqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable RetornaTabela(string strQuery)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdComando = new SqlCommand(strQuery, AbreBanco());
                SqlDataAdapter da = new SqlDataAdapter(cmdComando);
                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro na pesquisa da tabela" + erro.Message);
            }
            finally
            {
                FechaBanco(AbreBanco());
            }
        }
        public SqlDataReader RetornaLinha(string strQuery)
        {
            try
            {
                SqlDataReader dr;
                SqlCommand sqlComando = new SqlCommand(strQuery, AbreBanco());
                dr = sqlComando.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                throw e;
                throw new Exception("Mensagem");
            }
        }
        public void ExecutaComando(string strQuery)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(strQuery, AbreBanco());
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                //if(((ex.InnerException).InnerException).Message.Contains("UNIQUE KEY"))
                //{
                //    MessageBox.Show("Erro de Unique");
                //}
                //if(ex.InnerException is null)
                //{
                //    if(((SqlException)ex.InnerException).Number==2601)
                //    {
                //        MessageBox.Show("Erro de Unique");
                //    }
                //}

                
                //Int32 a = ((SqlException) e.InnerException).Number;

                throw ex ;
                              

            }
            finally
            {
                FechaBanco(AbreBanco());
            }
        }
    }
}
