namespace TA.MVC.Controllers
{
    using System.Web.Mvc;
    using Services;

    public class CustomersController : Controller
    {
        private readonly CustomerService customerService;

        public CustomersController()
        {
            this.customerService = new CustomerService();
        }

        public ActionResult Index(string searching)
        {
            var customers = this.customerService.GetAll(searching);

            return View(customers);
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

            return View(customer);
        }
    }
}