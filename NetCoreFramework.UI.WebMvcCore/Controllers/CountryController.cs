using Microsoft.AspNetCore.Mvc;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.UI.WebMvcCore.Models;

namespace NetCoreFramework.UI.WebMvcCore.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            var model = new CountryViewModel
            {
                Countries = _countryService.GetAll()
            };

            return View(model);
        }
    }
}