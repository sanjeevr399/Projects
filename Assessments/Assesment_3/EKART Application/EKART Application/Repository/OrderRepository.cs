using EKART_Application.Models;
using EKART_Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace EKART_Application.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)

        {

            _context = context;

        }

        public int PlaceOrder(string customerId, int productId, int quantity)

        {

            Order newOrder = new Order

            {
                CustomerId = customerId,

                OrderDate = DateTime.Now,

            };

            _context.Orders.Add(newOrder);

            _context.SaveChanges();

            return newOrder.OrderId;

        }

        public Order GetOrderDetails(int orderId)

        {

            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        }

        public void PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public decimal GetBill(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByOrderDate(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerWithHighestOrder()
        {
            throw new NotImplementedException();
        }

        List<Customer> IOrderRepository.GetCustomersByOrderDate(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public string? GetOrdersByDate(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public object GetCustomersByOrderDate(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}