using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;
using ProyectoWeb24AM.Services.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoWeb24AM.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroServices _LibroServices;
        public LibroController(ILibroServices libroServices)
        {
            _LibroServices = libroServices;

        }


        [HttpGet]
        public async Task<IActionResult> Libro()
        {
            try
            {
                var datos = await _LibroServices.GetLibros(); // Obtener datos desde el servicio

                // Pasar los datos a la vista "Libro.cshtml"
                return View("Libro", datos);
            }
            catch (Exception ex)
            {
                // Manejar errores
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public IActionResult Agregar()
        {
            // Lógica para preparar la vista Agregar
            return View();
        }

        //Aquí inicia nuevo código
        [HttpPost]
        public IActionResult Crear(Libro request)
        {
            try
            {
                var response= _LibroServices.CrearLibro(request);
                return RedirectToAction(nameof(Libro));

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _LibroServices.GetByIdLibro(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Libro request)
        {
            var response = _LibroServices.EditarLibro(request);
            return RedirectToAction(nameof(Libro));  // Redirigir a la acción "Libro" en lugar de "Editar"
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _LibroServices.EliminarLibro(id);
            if (result == true)  // Usar "=="
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }



    }
}
