namespace TA.MVC.Services
{
    using RestSharp;
    using Models;
    using System.Collections.Generic;

    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IRestClient restClient)
            :base(restClient)
        {
        }
       
        public List<Customer> GetAll(string filterName = null)
        {
            var request = new RestRequest("api/customers/?filterByName=" + filterName, Method.GET);
            var customers = base.restClient.Execute<List<Customer>>(request).Data;

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