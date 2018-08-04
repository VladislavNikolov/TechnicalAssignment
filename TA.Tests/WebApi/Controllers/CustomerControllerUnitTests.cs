namespace TA.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebApi.Controllers;
    using Moq;
    using BLL.Interfaces;
    using BLL.DTOs;
    using System.Collections.Generic;
    using System.Web.Http.Results;

    [TestClass]
    public class CustomerControllerUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockedCustomerService = new Mock<ICustomerService>();
            mockedCustomerService.Setup(x => x.GetAll()).Returns(new List<CustomerDTO>());

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<CustomerDTO>>;
            Assert.IsNotNull(response);
        }
    }
}
