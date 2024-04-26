using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DataApiService;
using DataApiService.Models;
using TerminalMVC.Models;
using System.Reflection;
using System.Text;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

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

            var model = await _dataManager.GetItems<CommandTypesResponse>("commands/types");

            if (!string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name1) &&
                !string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name2) &&
                !string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name3))
            {
                ViewBag.Name = model.Items.First(x => x.Id == ControllerId).Name;
                ViewBag.parameter_name1 = model.Items.First(x => x.Id == ControllerId).Parameter_name1;
                ViewBag.parameter_name2 = model.Items.First(x => x.Id == ControllerId).Parameter_name2;
                ViewBag.parameter_name3 = model.Items.First(x => x.Id == ControllerId).Parameter_name3;
                ViewBag.parameter_default_value1 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value1;
                ViewBag.parameter_default_value2 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value2;
                ViewBag.parameter_default_value3 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value3;

                return View("ThreeParametersPartialView");
            }

            else if (!string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name1) &&
                !string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name2))
            {
                ViewBag.Name = model.Items.First(x => x.Id == ControllerId).Name;
                ViewBag.parameter_name1 = model.Items.First(x => x.Id == ControllerId).Parameter_name1;
                ViewBag.parameter_name2 = model.Items.First(x => x.Id == ControllerId).Parameter_name2;
                ViewBag.parameter_default_value1 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value1;
                ViewBag.parameter_default_value2 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value2;

                return View("TwoParametersPartialView");
            }
            else if (!string.IsNullOrEmpty(model.Items.First(x => x.Id == ControllerId).Parameter_name1))
            {
                ViewBag.Name = model.Items.First(x => x.Id == ControllerId).Name;
                ViewBag.parameter_name1 = model.Items.First(x => x.Id == ControllerId).Parameter_name1;
                ViewBag.parameter_default_value1 = model.Items.First(x => x.Id == ControllerId).Parameter_default_value1;

                return View("OnceParametersPartialView");
            }
            else
            {
                return  View("ZeroParametersPartialView");
            }
            
        }

        [HttpPost]
        
        public async Task<IActionResult> TerminalResponse(int terminalId, Dictionary<string, string> GetParams)
        {
            var model = await _dataManager.GetPostItems<TerminalResponse>($"terminals/{terminalId}/commands", GetParams);
            var model2 = await _dataManager.GetItems<CommandTypesResponse>("commands/types");
            ViewBag.commandName=model2.Items.First(x => x.Id==model.item.Command_id).Name;
            ViewBag.state = model.item.State_name;
            ViewBag.date = model.item.Time_created;
            ViewBag.parameter1 = model.item.Parameter1;
            ViewBag.parameter2 = model.item.Parameter2;
            ViewBag.parameter3 = model.item.Parameter3;

            return PartialView("HistoryPartialView");
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