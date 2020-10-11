using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.UI.WebMvcCore.Models;

namespace NetCoreFramework.UI.WebMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICitiesOfCountriesService _dbViewService;

        public HomeController(ILogger<HomeController> logger, ICitiesOfCountriesService dbViewService)
        {
            _logger = logger;
            _dbViewService = dbViewService;
        }

        public IActionResult Index()
        {
            var test = _dbViewService.GetAll();

            var homeViewModel = new HomeViewModel
            {
         
            };
            return View(homeViewModel);
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
