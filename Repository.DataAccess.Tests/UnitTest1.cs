using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DataAccess.Concrete.EFCore;

namespace Repository.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cityDal = new EfCityDal();
            var cities = cityDal.GetList();

            Assert.AreEqual(cities.Count, 10);
        }
    }
}