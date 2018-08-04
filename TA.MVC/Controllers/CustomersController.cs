namespace TA.MVC.Controllers
{
    using System.Web.Mvc;
    using Services;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Index(string searching)
        {
            var customers = this.customerService.GetAll(searching);
            if (customers == null)
            {
                return RedirectToAction("DisplayError", "Error", new { area = "" });
            }

            return View("Index", customers);
        }

        public ActionResult CustomerDetails(string customerId)
        {
            var customer = this.customerService.GetById(customerId);
            if (customer == null)
            {
                return RedirectToAction("DisplayError", "Error", new { area = "" });
            }

            var orders = this.customerService.GetOrdersByCustomerId(customerId);
            if (orders == null)
            {
                return RedirectToAction("DisplayError", "Error", new { area = "" });
            }

            customer.Orders = orders;

            return View("CustomerDetails", customer);
        }
    }
}