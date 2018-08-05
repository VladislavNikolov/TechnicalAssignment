namespace TA.BLL.Interfaces
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAll(string filterByName = null);

        CustomerDTO GetById(string id);

        IEnumerable<OrderDTO> GetOrdersByCustomerId(string customerId); 
     }
}
