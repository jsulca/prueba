using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba.Entidades;
using Prueba.Logicas;

namespace Prueba.WebApp.Controllers
{
    public class CursoController : Controller
    {
        private CursoLogica _cursoLogica;

        #region Acciones

        public ActionResult Index()
        {
            _cursoLogica = new CursoLogica();
            return View(_cursoLogica.Listar());
        }

        public ActionResult Nuevo()
        {
            Curso model = new Curso { Activo = true };
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Curso model)
        {
            _cursoLogica = new CursoLogica();
            _cursoLogica.Guardar(model);
            return RedirectToAction("Index");
        }

        public  ActionResult Editar(int id)
        {
            _cursoLogica = new CursoLogica();
            Curso model = _cursoLogica.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Curso model)
        {
            _cursoLogica = new CursoLogica();
            _cursoLogica.Actualizar(model);
            return RedirectToAction("Index");
        }

        #endregion
    }
}