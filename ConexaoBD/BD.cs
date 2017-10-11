using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    public class BD : IDisposable
    {
        private readonly SqlConnection conexao;

        public BD()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdInsert = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            cmdInsert.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdSelect = new SqlCommand(strQuery, conexao);
            return cmdSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if(conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
