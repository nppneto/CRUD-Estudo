using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using BDProjeto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BDProjeto.RepositorioADO
{
    public class UsuarioAplicacaoADO : IRepositorio<Usuario>
    {
        private BD bd;

        private void Insert(Usuario Usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Usuario (Nome, Cargo, Data)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')", Usuario.Nome, Usuario.Cargo, Usuario.Data);

            using (bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Update(Usuario Usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE Usuario SET ";
            strQuery += string.Format("Nome = '{0}',", Usuario.Nome);
            strQuery += string.Format("Cargo = '{0}',", Usuario.Cargo);
            strQuery += string.Format("Data = '{0}'", Usuario.Data);
            strQuery += string.Format("WHERE UsuarioId = '{0}' ", Usuario.Id);

            using (bd = new BD())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Save(Usuario Usuario)
        {
            if (Usuario.Id > 0)
            {
                Update(Usuario);
            }
            else
                Insert(Usuario);
        }

        public void Delete(Usuario usuario)
        {
            using (bd = new BD())
            {
                var strQuery = string.Format("DELETE FROM Usuario WHERE UsuarioId = {0}", usuario.Id);
                bd.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Usuario> SelectAll()
        {
            using (bd = new BD())
            {
                var strQuery = "SELECT * FROM Usuario";
                var retorno =  bd.ExecutaComandoComRetorno(strQuery);
                return ListarUsuario(retorno);
            }
        }

        public Usuario SelectById(string id)
        {
            using (bd = new BD())
            {
                var strQuery = string.Format("SELECT * FROM Usuario WHERE UsuarioId = {0}", id);
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ListarUsuario(retorno).FirstOrDefault();
            }
        }

        private List<Usuario>ListarUsuario(SqlDataReader Reader)
        {

            var Usuario = new List<Usuario>();

            while(Reader.Read())
            {
                var TempUsuario = new Usuario()
                {
                    Id = int.Parse(Reader["UsuarioId"].ToString()),
                    Nome = Reader["Nome"].ToString(),
                    Cargo = Reader["Cargo"].ToString(),
                    Data = DateTime.Parse(Reader["Data"].ToString())
                };

                Usuario.Add(TempUsuario);
            }
            Reader.Close();
            return Usuario;
        }
    }
}
