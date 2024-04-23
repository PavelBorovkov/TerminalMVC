using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DataApiService;
using DataApiService.Models;
using TerminalMVC.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataManager _dataManager;
         

        public HomeController(ILogger<HomeController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _dataManager.Auth("user1", "password1");
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dataManager.GetItems<CommandTypesResponse>("commands/types");


            return View(model);
        }

        [HttpGet]
        public IActionResult GetParameters(int ControllerId)
        {

            return View("ParametersPartialView", ControllerId);
        }


        public IActionResult Privacy()
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