using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {
            var bd = new BD();

            SqlConnection conexao = new SqlConnection(@"Data Source=CODESP1855\NELSON;Initial Catalog=ExemploBD;User ID=sa;Password=codinome");
            conexao.Open();

            //string queryUpdate = "UPDATE Usuario SET nome = 'Fabio' WHERE UsuarioId = 1";
            //SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexao);
            //cmdUpdate.ExecuteNonQuery();

            Console.Write("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o cargo do usuário: ");
            string cargo = Console.ReadLine();

            Console.Write("Digite a data de registro do usuário: ");
            string data = Console.ReadLine();

            string queryInsert = string.Format("INSERT INTO Usuario (Nome, Cargo, Data) VALUES ('{0}', '{1}', '{2}')", nome, cargo, data);
            bd.ExecutaComando(queryInsert);

            string querySelect = "SELECT * FROM Usuario";
            SqlDataReader dados = bd.ExecutaComandoComRetorno(querySelect);

            while (dados.Read())
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", dados["UsuarioId"], dados["Nome"], dados["Cargo"], dados["Data"]);
            }
        }
    }
}
