using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Moq;
using NetCoreFramework.Repository.Business.Concrete;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetListTest()
        {
            var cityManager = new CityManager(new Mock<ICityDal>().Object);

            cityManager.GetAll();
        }

        //[TestMethod]
        //public async void GetByIdTest()
        //{
        //    var cityManager = new CityManager(new Mock<ICityDal>().Object);

        //    var a = await cityManager.GetById(1);
        //}


        //[TestMethod]
        //[ExpectedException(typeof(ValidationException))]
        //public void FluentValidationCheck()
        //{
        //    var productDalMock = new Mock<ICityDal>();

        //    var productManager = new CityManager(productDalMock.Object);

        //    productManager.Add(new City
        //    {
        //        Name = "Kent"
        //    });
        //}
    }
}