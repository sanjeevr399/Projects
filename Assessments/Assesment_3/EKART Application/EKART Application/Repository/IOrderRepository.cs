using EKART_Application.Models;

namespace EKART_Application.Repository
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        Order GetOrderDetails(int orderId);
        decimal GetBill(int orderId);
        List<Customer> GetCustomersByOrderDate(DateTime orderDate);
        Customer GetCustomerWithHighestOrder();
        string? GetOrdersByDate(DateTime orderDate);
        //object GetCustomersByOrderDate(int customerId);
    }
}
