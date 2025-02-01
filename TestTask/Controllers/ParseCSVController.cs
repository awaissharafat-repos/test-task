using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestTask.BLL.Interfaces;

namespace TestTask.Controllers
{
    [Authorize]
    public class ParseCSVController : Controller
    {
        private readonly ILogger<ParseCSVController> _logger;
        private readonly IParseCSVService _parseCSVService;

        public ParseCSVController(ILogger<ParseCSVController> logger, IParseCSVService parseCSVService)
        {
            _logger = logger;
            _parseCSVService = parseCSVService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "No file selected.";
                return View("Index");
            }

            using var stream = file.OpenReadStream();
            List<dynamic> data = _parseCSVService.ParseCsv(stream);
            // Convert data to JSON string and store in ViewBag for display
            ViewBag.JsonResult = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            return View("Index");
        }

    }
}
