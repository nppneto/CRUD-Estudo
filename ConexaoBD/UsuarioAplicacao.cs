using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    public class UsuarioAplicacao
    {
        private BD bd;

        public void Insert()
        {
            var strQuery = "";
            strQuery += "INSERT INTO Usuario (Nome, Cargo, Data)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')");
        }
    }
}
