using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVaultDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KeyVaultDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;

        }

        public String CreateSecret()
        {
            try
            {
                var cliente = new SecretClient(new Uri(@"https://key4trainner.vault.azure.net/"),
                    new InteractiveBrowserCredential());
                cliente.SetSecret("Secreto", "La Harina engorda");
                return "Secreto creado";

            }catch(Exception ex) {
                return ex.Message;
            }
        }

        public IActionResult Index()
        {
            this.ViewBag.Password = this._configuration.GetValue<String>("Password");
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