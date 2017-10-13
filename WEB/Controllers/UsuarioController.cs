using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioAplicacao appUsuario;

        public UsuarioController()
        {
            appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var listaUsuario = appUsuario.SelectAll();
            return View(listaUsuario);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario Usuario)
        {
            if(ModelState.IsValid)
            {
                //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
                appUsuario.Save(Usuario);
                return RedirectToAction("Index");
            }

            return View(Usuario);
        }

        public ActionResult Editar(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var usuario = appUsuario.SelectById(id);

            if(usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
                appUsuario.Save(Usuario);
                return RedirectToAction("Index");
            }

            return View(Usuario);
        }

        public ActionResult Detalhes(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var usuario = appUsuario.SelectById(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        public ActionResult Excluir(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var usuario = appUsuario.SelectById(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var usuario = appUsuario.SelectById(id);
            appUsuario.Delete(usuario);
            return RedirectToAction("Index");
        }
    }
}