using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleSiteMvc.Models;
using SimpleSiteMvc.Models.Workers;

namespace SimpleSiteMvc.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ILogger<WorkersController> _logger;

        public WorkersController(ILogger<WorkersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // обратились к базе
            var model = new PrivaceModel();
            model.Name = "Иван";
            model.Age = 19;
            return View("Test222", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
