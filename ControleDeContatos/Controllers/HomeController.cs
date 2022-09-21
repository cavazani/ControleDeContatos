using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleDeContatos.Controllers {
    public class HomeController : Controller {
        // private readonly ILogger<HomeController> _logger;               //Apagar

        //public HomeController(ILogger<HomeController> logger) {         //Apagar Construtor dessa controller
        //    _logger = logger;
        //}

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}