using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using BDProjeto.RepositorioADO;
using System.Collections.Generic;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<Usuario> repositorio;

        public UsuarioAplicacao(IRepositorio<Usuario> repo)
        {
            repositorio = repo;
        }

        public void Save(Usuario Usuario)
        {
            repositorio.Save(Usuario);
        }

        public void Delete(Usuario usuario)
        {
            repositorio.Delete(usuario);
        }

        public IEnumerable<Usuario> SelectAll()
        {
            return repositorio.SelectAll();
        }

        public Usuario SelectById(string id)
        {
            return repositorio.SelectById(id);
        }

    }
}
