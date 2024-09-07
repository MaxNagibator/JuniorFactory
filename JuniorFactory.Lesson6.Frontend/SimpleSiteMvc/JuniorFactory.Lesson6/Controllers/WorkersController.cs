using System.Diagnostics;
using JuniorFactory.Lesson6.Models;
using JuniorFactory.Lesson6.Models.Workers;
using Microsoft.AspNetCore.Mvc;

namespace JuniorFactory.Lesson6.Controllers
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
            // ���������� � ����
            var model = new PrivaceModel();
            model.Name = "����";
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
