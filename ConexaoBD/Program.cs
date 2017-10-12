﻿using System;
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
            var app = new UsuarioAplicacao();

            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-PF66N0S\SQLEXPRESS;Initial Catalog=ExemploBD;User ID=sa;Password=codinome");
            conexao.Open();

            //string queryUpdate = "UPDATE Usuario SET nome = 'Fabio' WHERE UsuarioId = 1";
            //SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexao);
            //cmdUpdate.ExecuteNonQuery();

            var Usuario = new Usuario();


            //Console.Write("Digite o nome do usuário: ");
            //Usuario.Nome = Console.ReadLine();

            //Console.Write("Digite o cargo do usuário: ");
            //Usuario.Cargo = Console.ReadLine();

            //Console.Write("Digite a data de registro do usuário: ");
            //Usuario.Data = DateTime.Parse(Console.ReadLine());

            ////string queryInsert = string.Format("INSERT INTO Usuario (Nome, Cargo, Data) VALUES ('{0}', '{1}', '{2}')", nome, cargo, data);
            ////bd.ExecutaComando(queryInsert);

            //Usuario.Id = 13;

            //app.Save(Usuario);

            //app.Delete(13);

            var dados = app.SelectAll();

            foreach(var usuario in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }
        }
    }
}
