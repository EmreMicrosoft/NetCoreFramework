using System.Collections.Generic;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.UI.WebMvcCore.Models
{
    public class HomeViewModel
    {
        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
    }
}