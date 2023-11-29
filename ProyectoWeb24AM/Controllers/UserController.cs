using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsuarioServices _UsuarioServices;
        private readonly ApplicationDBContext _context;
        public UserController(IUsuarioServices UserServices, ApplicationDBContext context)
        {
            _UsuarioServices = UserServices;
            _context = context;

        }


        [HttpGet]
        public async Task<IActionResult> Usuario()
        {
            try
            {
                var datos = await _UsuarioServices.GetAll(); // Obtener datos desde el servicio

               
                return View("~/Views/User/Usuario.cshtml", datos);
            }
            catch (Exception ex)
            {
                // Manejar errores
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

      
        
 


        //Aquí inicia nuevo código
        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            try
            {
                var response = _UsuarioServices.Crear(request);
                return RedirectToAction(nameof(Usuario));

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text=p.Nombre,
                Value=p.PKRol.ToString()
            });
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _UsuarioServices.GetByIdUsuario(id);
            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PKRol.ToString()
            });
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario request)
        {
            var response = await _UsuarioServices.EditarUser(request);
            return RedirectToAction(nameof(Usuario));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _UsuarioServices.EliminarUsuario (id);
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
