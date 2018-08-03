namespace TA.BLL.Interfaces
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAll();

        CustomerDTO GetById(string id);

        IEnumerable<OrderDTO> GetOrdersByCustomerId(string customerId); 
     }
}
