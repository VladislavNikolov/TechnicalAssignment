namespace TA.WebApi.Controllers
{
    using System.Web.Http;
    using BLL.Interfaces;

    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IHttpActionResult GetAll(string filterByName = null)
        {
            var customers = this.customerService.GetAll(filterByName);

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(string id)
        {
            var customer = this.customerService.GetById(id);
            if (customer == null)
            {
                return BadRequest("Please provide valid ID.");
            }

            return Ok(customer);
        }

        [HttpGet]
        [Route("{customerId}/orders")]
        public IHttpActionResult GetOrdersByCustomerId(string customerId)
        {
            var orders = this.customerService.GetOrdersByCustomerId(customerId);
            if (orders == null)
            {
                return BadRequest("Please provide valid ID.");
            }

            return Ok(orders);
        }
    }
}
