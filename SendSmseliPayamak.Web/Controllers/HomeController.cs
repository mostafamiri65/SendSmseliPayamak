using Microsoft.AspNetCore.Mvc;
using SendSmseliPayamak.Web.Models;
using System.Diagnostics;
using System.Web.Mvc;
using mpNuget;
using ServiceReference1;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using RestClient = SendSmseliPayamak.Web.Models.RestClient;


namespace SendSmseliPayamak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult? Send(string to,string message)
        {
            const string username = "********";
            const string password = "********";
            const string from = "30008666483765";
            
           
            const bool isFlash = false;
            RestClient restClient = new RestClient(username, password);
            var result = restClient.Send(to, from, message, isFlash);
            return RedirectToAction("Index");
        }

        public IActionResult SendWithPattern()
        {
            const string username = "*********";
            const string password = "******";
            const string to = "*****";
            string[] text = { "12345","" };
            RestClient soapClient = new RestClient(username,password);
            soapClient.SendByBaseNumber( text[0], to, 39459);
            return RedirectToAction("Index");
        }
            
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}