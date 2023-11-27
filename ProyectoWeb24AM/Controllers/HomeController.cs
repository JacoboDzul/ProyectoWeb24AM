using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb24AM.Context;
using ProyectoWeb24AM.Models;
using ProyectoWeb24AM.Services.IServices;
using System.Diagnostics;

namespace ProyectoWeb24AM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticuloServices _articuloServices;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, IArticuloServices articuloServices,ApplicationDBContext context)
        {
            _articuloServices = articuloServices;
            _logger = logger;
            _context= context;  
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
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {

            var response = _context.Usuarios.Include(z => z.Roles)
                                                    .FirstOrDefault(x => x.UserName == user && x.Password == password);


            if (response != null)
            {
                if (response.Roles.Nombre == "admin")
                {
                    return Json(new { Success = true, admin = true });
                }
                return Json(new { Success = true, admin = false });
            }
            else
            {
                return Json(new { Success = false, admin = false });
            }

        }



    }
}