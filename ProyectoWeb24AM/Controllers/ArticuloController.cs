using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoWeb24AM.Models.Entities;
using ProyectoWeb24AM.Services.IServices;

namespace ProyectoWeb24AM.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly IArticuloServices _articuloServices;

        public ArticuloController(IArticuloServices articuloServices)
        {
            _articuloServices = articuloServices;

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                //var response = await _articuloServices.GetArticulos();

                //return View(response);

                return View(await _articuloServices.GetArticulos());


            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> IndexCopia()
        {
            try
            {

                //var response = await _articuloServices.GetArticulos();

                //return View(response);

                return View(await _articuloServices.GetArticulos());


            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Crear(Articulo request)
        {
            try
            {
                var response = _articuloServices.CrearArticulo(request);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
            
        }

        [HttpGet]
        public async  Task<IActionResult> Editar(int id)
        {
            var response = await _articuloServices.GetByIdArticulo(id);
            return View(response);
        }

        [HttpPost]
        public async  Task<IActionResult> Editar(Articulo request)
        {
            var response = _articuloServices.EditarArticulo(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _articuloServices.EliminarArticulo(id);
                if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }

        }


        [HttpGet]
        public IActionResult NewArticulo()
        {
            return View();
        }
    }
}
