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
        private Mock<ICustomerService> mockedCustomerService;

        [TestInitialize()]
        public void Initialize()
        {
            this.mockedCustomerService = new Mock<ICustomerService>();
        }

        [TestMethod]
        public void GetAll_ShouldReturnOkWithIListOfCustomerDTOs()
        {
            mockedCustomerService.Setup(x => x.GetAll()).Returns(new List<CustomerDTO>());

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<CustomerDTO>>;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetById_WithValidId_ShouldReturnOkWithCustomerDTO()
        {
            mockedCustomerService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new CustomerDTO());

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetById(string.Empty) as OkNegotiatedContentResult<CustomerDTO>;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetById_WithInvalidId_ShouldReturnBadRequestWithMessage()
        {
            mockedCustomerService.Setup(x => x.GetById(It.IsAny<string>())).Returns((CustomerDTO)null);

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetById(string.Empty) as BadRequestErrorMessageResult;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetOrdersByCustomerId_WithValidId_ShouldReturnOkWithIEnumerableOfOrderDTOs()
        {
            mockedCustomerService.Setup(x => x.GetOrdersByCustomerId(It.IsAny<string>())).Returns(new List<OrderDTO>());

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetOrdersByCustomerId(string.Empty) as OkNegotiatedContentResult<IEnumerable<OrderDTO>>;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetOrdersByCustomerId_WithInvalidId_ShouldReturnBadRequestWithMessage()
        {
            mockedCustomerService.Setup(x => x.GetOrdersByCustomerId(It.IsAny<string>())).Returns((List<OrderDTO>)null);

            var controller = new CustomersController(mockedCustomerService.Object);

            var response = controller.GetOrdersByCustomerId(string.Empty) as BadRequestErrorMessageResult;
            Assert.IsNotNull(response);
        }
    }
}
