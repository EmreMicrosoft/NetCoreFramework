using Microsoft.AspNetCore.Mvc;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.UI.WebMvcCore.Models;

namespace NetCoreFramework.UI.WebMvcCore.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var model = new CityViewModel
            {
                Cities = _cityService.GetAll()
            };

            return View(model);
        }
    }
}