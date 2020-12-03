using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mecânica
{
    public class Controle
    { 

        public bool tem;
        public String messagem = ""; 
        public bool Acessar(String login, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLogin( login, senha);
            if (!loginDao.mensagem.Equals(""))
            {
                this.messagem = loginDao.mensagem;
            }
            return tem;
        }
        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
           this.messagem =  loginDao.cadastrar(email, senha, confSenha);
            if (loginDao.tem)
            {
                this.tem = true;
            }


                return messagem;
        }
    }
}
