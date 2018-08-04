namespace TA.MVC.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ICustomerService
    {
        List<Customer> GetAll();

        List<Customer> GetAll(string filterName);

        Customer GetById(string id);

        List<Order> GetOrdersByCustomerId(string customerId);
    }
}
