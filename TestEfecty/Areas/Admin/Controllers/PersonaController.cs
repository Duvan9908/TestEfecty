using Microsoft.AspNetCore.Mvc;
using Sistema.AccesoDatos.Repositorio.IRepositorio;
using Sistema.Modelos;

namespace TestEfecty.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public PersonaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET para la vista Upser, upsert es dinamica y sirve para la creación y la edición de registros.
        public async Task<IActionResult> Upsert(int? id)
        {
            Persona personas = new Persona();

            if(id == null)
            {
                return View(personas);
            }
            personas = await _unidadTrabajo.Persona.Obtener(id.GetValueOrDefault());
            if(personas == null)
            {
                return NotFound();
            }
            return View(personas);
        }

        //POST guarda y edita
        [HttpPost]
        public async Task<IActionResult> Upsert(Persona personas)
        {
            if (ModelState.IsValid)
            {
                if(personas.Id == 0)
                {
                    await _unidadTrabajo.Persona.Agregar(personas);
                }
                else
                {
                    _unidadTrabajo.Persona.Actualizar(personas);
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(personas);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Persona.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var personas = await _unidadTrabajo.Persona.Obtener(id);
            if(personas == null)
            {
                return Json(new { success = false, message = "Error" });
            }
            _unidadTrabajo.Persona.Remover(personas);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Exito" });
        }
    }
}
