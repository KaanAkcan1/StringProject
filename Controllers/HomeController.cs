using Interface.Models;
using Microsoft.AspNetCore.Mvc;
using Interface.Services;

namespace Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainService _main;

        public HomeController(ILogger<HomeController> logger,MainService main)
        {
            _main = main;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/save-log")]
        [HttpPost]
        public IResult SaveLogs ([FromBody] Log request)
        {
            var response = _main.SaveLog(request);

            return Results.Json(new { Success = response.Success });
        }

        [Route("/save-string")]
        [HttpPost]
        public IResult SaveString([FromBody]string[] request)
        {
            var response = _main.SaveString(request);

            return Results.Json(new { Success = response.Success });
        }

        [Route("/show-string")]
        [HttpGet]
        public IResult GetString()
        {
            var response = _main.ShowString();
            if (!response.Success)
                return Results.BadRequest();
            return Results.Ok(response.Data);
        }

        [Route("/show-logs")]
        [HttpGet]
        public IResult GetLogs()
        {
            var response = _main.ShowLogs();
            if (!response.Success)
                return Results.BadRequest();
            return Results.Ok(response.Data);
        }

    }
}