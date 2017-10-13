using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuario>
    {

        private readonly BD bd;

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }

        public void Delete(Usuario entidade)
        {
            var usuarioExcluir = bd.Usuario.First(x => x.Id == entidade.Id);
            bd.Set<Usuario>().Remove(usuarioExcluir);

            bd.SaveChanges();
        }

        public void Save(Usuario entidade)
        {
            if(entidade.Id > 0)
            {
                var usuarioAlterar = bd.Usuario.First(x => x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Cargo = entidade.Cargo;
                usuarioAlterar.Data = entidade.Data;
            }
            else
            {
                bd.Usuario.Add(entidade);
            }

            bd.SaveChanges();
        }

        public IEnumerable<Usuario> SelectAll()
        {
            return bd.Usuario;
        }

        public Usuario SelectById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return bd.Usuario.First(x => x.Id == idInt);
        }
    }
}
