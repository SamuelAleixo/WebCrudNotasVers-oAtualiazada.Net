using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrudNotasVersãoAtualiazada.Net.Models;

namespace WebCrudNotasVersãoAtualiazada.Net.Models.Controllers
{
    public class HomeController : Controller
    {
        AlunoDAO obj = new AlunoDAO();
        public ActionResult Index()
        {
            List<Aluno> lista = obj.lisAluno();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Aluno alu)
        {
            obj.Agregar(alu);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            Aluno a = obj.ObtenerPorId(id);

            return View(a);
        }

        [HttpPost]
        public ActionResult Modificar(Aluno alu)
        {
            obj.Modificar(alu);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EliminarAlu(int id)
        {
            obj.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}