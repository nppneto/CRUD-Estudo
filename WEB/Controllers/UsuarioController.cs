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
        // GET: Usuario
        public ActionResult Index()
        {
            var appUsuario = new UsuarioAplicacao();
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
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Save(Usuario);
                return RedirectToAction("Index");
            }

            return View(Usuario);
        }

        public ActionResult Editar(int id)
        {
            var appUsuario = new UsuarioAplicacao();
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
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Save(Usuario);
                return RedirectToAction("Index");
            }

            return View(Usuario);
        }

        public ActionResult Detalhes(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.SelectById(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.SelectById(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            appUsuario.Delete(id);
            return RedirectToAction("Index");
        }
    }
}