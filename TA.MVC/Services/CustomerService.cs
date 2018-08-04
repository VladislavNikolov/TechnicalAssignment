namespace TA.MVC.Services
{
    using RestSharp;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IRestClient restClient)
            :base(restClient)
        {
        }

        public List<Customer> GetAll()
        {
            return this.GetAll(null);
        }

        public List<Customer> GetAll(string filterName)
        {
            var request = new RestRequest("api/customers", Method.GET);

            var customers = base.restClient.Execute<List<Customer>>(request).Data;
            if (customers != null && filterName != null)
            {
                customers = customers.Where(c => c.ContactName.ToLower().Contains(filterName.ToLower())).ToList();
            }

            return customers;
        }

        public Customer GetById(string id)
        {
            var request = new RestRequest("api/customers/" + id, Method.GET);
            var customer = base.restClient.Execute<Customer>(request).Data;

            return customer;
        }

        public List<Order> GetOrdersByCustomerId(string customerId)
        {
            var request = new RestRequest("api/customers/" + customerId + "/orders", Method.GET);
            var orders = base.restClient.Execute<List<Order>>(request).Data;

            return orders;
        }
    }
}