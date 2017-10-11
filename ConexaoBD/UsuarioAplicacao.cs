using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    public class UsuarioAplicacao
    {
        private BD bd;

        public void Insert(string nome, string cargo, string data)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Usuario (Nome, Cargo, Data)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')", nome, cargo, data);

            using (bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public SqlDataReader Select()
        {
            var strQuery = "SELECT * FROM Usuario";

            using (bd = new BD())
            {
                return bd.ExecutaComandoComRetorno(strQuery);
            }
        }
    }
}
