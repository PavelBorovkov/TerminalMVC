using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DataApiService;
using DataApiService.Models;
using TerminalMVC.Models;
using System.Reflection;

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

       

        
        public async Task<IActionResult> ParametersPartialView(int ControllerId)
        {

            var models = await  _dataManager.GetItems<CommandTypesResponse>("commands/types");
            //ConcreteCommand concreteCommand=new ConcreteCommand();
            //concreteCommand.commandTypeResponse = models;
            //concreteCommand.CommandId = ControllerId;
            ViewBag.Name = models.Items.First(x=>x.Id==ControllerId).Name;
            ViewBag.parameter_name1=models.Items.First(x => x.Id == ControllerId).Parameter_name1;
            ViewBag.parameter_name2 = models.Items.First(x => x.Id == ControllerId).Parameter_name2;
            ViewBag.parameter_name3 = models.Items.First(x => x.Id == ControllerId).Parameter_name3;
            ViewBag.parameter_default_value1 = models.Items.First(x => x.Id == ControllerId).Parameter_default_value1;
            ViewBag.parameter_default_value2 = models.Items.First(x => x.Id == ControllerId).Parameter_default_value2;
            ViewBag.parameter_default_value3 = models.Items.First(x => x.Id == ControllerId).Parameter_default_value3;
            /*CommandTypesViewModel model = models.Items.FirstOrDefault(x => x.Id == ControllerId)*/ /*models.Result.Items.First(x => x.Id == ControllerId)*/
            
            //var model = ControllerId;
            return View();
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