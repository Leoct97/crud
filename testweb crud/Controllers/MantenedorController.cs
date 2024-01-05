using Microsoft.AspNetCore.Mvc;
using testweb_crud.Datos;
using testweb_crud.Models;

namespace testweb_crud.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devolver la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Contactomodel oContacto)
        {
            //recibir un objeto y guardarlo en BD
            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
