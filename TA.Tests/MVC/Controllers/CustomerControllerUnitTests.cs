namespace TA.Tests.MVC.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TA.MVC.Controllers;
    using TA.MVC.Models;
    using TA.MVC.Services;

    [TestClass]
    public class CustomerControllerUnitTests
    {
        private Mock<ICustomerService> mockedCustomerService;

        [TestInitialize()]
        public void Initialize()
        {
            this.mockedCustomerService = new Mock<ICustomerService>();
        }

        [TestMethod]
        public void Index_WithCustomersReturned_CorrectViewIsReturned()
        {
            mockedCustomerService.Setup(x => x.GetAll(It.IsAny<string>())).Returns(new List<Customer>());
            var controller = new CustomersController(mockedCustomerService.Object);

            var result = controller.Index(null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Index_WithNullReturned_ShouldRedirectToCorrectAction()
        {
            mockedCustomerService.Setup(x => x.GetAll(It.IsAny<string>())).Returns((List<Customer>)null);
            var controller = new CustomersController(mockedCustomerService.Object);

            var result = controller.Index(null) as RedirectToRouteResult;

            Assert.AreEqual("DisplayError", result.RouteValues["action"]);
        }

        [TestMethod]
        public void CustomerDetails_WithOrdersReturned_CorrectViewIsReturned()
        {
            mockedCustomerService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new Customer());
            mockedCustomerService.Setup(x => x.GetOrdersByCustomerId(It.IsAny<string>())).Returns(new List<Order>());
            var controller = new CustomersController(mockedCustomerService.Object);

            var result = controller.CustomerDetails(string.Empty) as ViewResult;

            Assert.AreEqual("CustomerDetails", result.ViewName);
        }

        [TestMethod]
        public void CustomerDetails_WithInvalidCustomerId_ShouldRedirectToCorrectAction()
        {
            mockedCustomerService.Setup(x => x.GetById(It.IsAny<string>())).Returns((Customer)null);
            var controller = new CustomersController(mockedCustomerService.Object);

            var result = controller.CustomerDetails(string.Empty) as RedirectToRouteResult;

            Assert.AreEqual("DisplayError", result.RouteValues["action"]);
        }
    }
}
