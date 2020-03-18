using Kitchen.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Kitchen.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items = new DishViewModel[] 
            { 
                new DishViewModel { Name = "Пиле фрикасе", Category = "Основно", Price = 6.70, Description = "Изваждат се и в същия съд се запържват наситнените праз и чесън. Добавят се морковите и целината, нарязани на кубчета и също се запържват. Подреждат се бутчетата, похлупва се и се оставя да се готви на умерен огън 20–30 минути.Накрая се прибавя и размразеният грах, и щом стане готов, ястието се дърпа от огъня и се сервира с наситнен магданоз.", Allergens = "Мляко, Яйца" }
            };
            return View(items);
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
