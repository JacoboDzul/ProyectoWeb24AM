using Microsoft.AspNetCore.Mvc;
using ProyectoWeb24AM.Models;
using ProyectoWeb24AM.Services.IServices;
using System.Diagnostics;

namespace ProyectoWeb24AM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticuloServices _articuloServices;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IArticuloServices articuloServices)
        {
            _articuloServices = articuloServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> Privacy()
        {
            var response = await _articuloServices.GetArticulos();
            return View(response);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}