using Microsoft.AspNetCore.Mvc;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Controllers
{
    
        public class RolController : Controller
        {
            private readonly IRolServices _RolServices;
            public RolController(IRolServices rolServices)
            {
                _RolServices = rolServices;

            }


            [HttpGet]
            public async Task<IActionResult> Roles()
            {
                try
                {
                    var datos = await _RolServices.GetAll(); // Obtener datos desde el servicio

                return View("~/Views/Rol/Roles.cshtml", datos);
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    throw new Exception("Sucedió un error" + ex.Message);
                }
            }

            //Aquí inicia nuevo código
            [HttpPost]
            public IActionResult Crear(Rol request)
            {
                try
                {
                    var response = _RolServices.CrearRol(request);
                    return RedirectToAction(nameof(Rol));

                }
                catch (Exception ex)
                {

                    throw new Exception("Sucedió un error" + ex.Message);
                }

            }

            [HttpGet]
            public async Task<IActionResult> Editar(int id)
            {
                var response = await _RolServices.GetByIdRol(id);
                return View(response);
            }

            [HttpPost]
            public async Task<IActionResult> Editar(Rol request)
            {
                var response = _RolServices.EditarRol(request);
                return RedirectToAction(nameof(Index));
            }

            [HttpDelete]
            public IActionResult Eliminar(int id)
            {
                bool result = _RolServices.EliminarRol(id);
                if (result = true)
                {
                    return Json(new { succes = true });
                }
                else
                {
                    return Json(new { succes = false });
                }

            }


        }
    }

