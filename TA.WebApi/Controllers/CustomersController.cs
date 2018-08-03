namespace TA.WebApi.Controllers
{
    using System.Web.Http;
    using BLL.Interfaces;
    using BLL.Services;

    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController()
        {
            this.customerService = new CustomerService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customers = this.customerService.GetAll();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(string id)
        {
            var customer = this.customerService.GetById(id);

            return Ok(customer);
        }

        [HttpGet]
        [Route("{customerId}/orders")]
        public IHttpActionResult GetOrdersByCustomerId(string customerId)
        {
            var orders = this.customerService.GetOrdersByCustomerId(customerId);

            return Ok(orders);
        }
    }
}
