namespace TA.BLL.Services
{
    using DAL;
    using System.Collections.Generic;
    using System.Linq;
    using DTOs;
    using Interfaces;
    using DAL.Repositories;

    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IBaseRepository<Customer> repository)
            :base(repository)
        {
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = base.repository
                .GetAll()
                .Select(c => new CustomerDTO
                {
                    CustomerID = c.CustomerID,
                    ContactName = c.ContactName,
                    OrdersCount = c.Orders.Count
                });

            return customers.ToList();
        }

        public CustomerDTO GetById(string id)
        {
            var customer = base.repository.GetById(id);

            CustomerDTO customerDto = null;
            if (customer != null)
            {
                customerDto = new CustomerDTO
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    OrdersCount = customer.Orders.Count
                };
            }

            return customerDto;
        }

        public IEnumerable<OrderDTO> GetOrdersByCustomerId(string customerId)
        {
            var customer = base.repository.GetById(customerId);
            if (customer == null)
            {
                return null;
            }

            var result = new List<OrderDTO>();
            foreach (var order in customer.Orders)
            {
                var orderDto = new OrderDTO()
                {
                    TotalSum = order.Order_Details.Sum(od => (od.UnitPrice - (decimal)od.Discount) * od.Quantity),
                    ProductsCount = order.Order_Details.Count,
                    MayHaveIssues = order.Order_Details.Any(od => od.Product.Discontinued || (od.Product.UnitsInStock < od.Product.UnitsOnOrder))
                };

                result.Add(orderDto);
            }

            return result;
        }

        //private bool OrderMayHaveIssues(Order order)
        //{
        //    bool result = false;
        //    foreach (var orderDetail in order.Order_Details)
        //    {
        //        if (orderDetail.Product.Discontinued || orderDetail.Product.UnitsInStock < orderDetail.Product.UnitsOnOrder)
        //        {
        //            result = true;
        //            break;
        //        }
        //    }

        //    return result;
        //}
    }
}
