using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System;
using System.Data.SqlClient;

namespace DOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new UsuarioAplicacao();

            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-PF66N0S\SQLEXPRESS;Initial Catalog=ExemploBD;User ID=sa;Password=codinome");
            conexao.Open();

            var Usuario = new Usuario();

            Console.Write("Digite o nome do usuário: ");
            Usuario.Nome = Console.ReadLine();

            Console.Write("Digite o cargo do usuário: ");
            Usuario.Cargo = Console.ReadLine();

            Console.Write("Digite a data de registro do usuário: ");
            Usuario.Data = DateTime.Parse(Console.ReadLine());

            //Usuario.Id = 13;

            app.Save(Usuario);

            var dados = app.SelectAll();

            foreach(var usuario in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }
        }
    }
}
