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

        public IEnumerable<CustomerDTO> GetAll(string filterByName = null)
        {
            var customers = base.repository.GetAll();
            if (filterByName != null)
            {
                customers = customers.Where(c => c.ContactName.ToLower().Contains(filterByName.ToLower()));
            }

            var result = customers.Select(c => new CustomerDTO
                {
                    CustomerID = c.CustomerID,
                    ContactName = c.ContactName,
                    OrdersCount = c.Orders.Count
                });

            return result.ToList();
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
            var result = base.repository
                .GetAll()
                .Where(c => c.CustomerID == customerId)
                .SelectMany(c => c.Orders)
                .SelectMany(o => o.Order_Details, (o, od) => new
                {
                    o.OrderID,
                    od.UnitPrice,
                    od.Discount,
                    od.Quantity,
                    od.Product.Discontinued,
                    od.Product.UnitsInStock,
                    od.Product.UnitsOnOrder,
                })
                .ToList()
                .GroupBy(o => o.OrderID)
                .Select(g => new OrderDTO
                {
                    ProductsCount = g.Count(),
                    TotalSum = g.Sum(od => (od.UnitPrice - (decimal)od.Discount) * od.Quantity),
                    MayHaveIssues = g.Any(od => od.Discontinued || (od.UnitsInStock < od.UnitsOnOrder))
                });

            return result;
        }
    }
}
