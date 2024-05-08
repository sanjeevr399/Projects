using EKART_Application.Models;
using EKART_Application.Repository;
using Microsoft.AspNetCore.Mvc;
namespace EKART_Application.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            _orderRepository.PlaceOrder(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ShowOrderDetails(int orderId)
        {
            var order = _orderRepository.GetOrderDetails(orderId);
            return View(order);
        }

        [HttpGet]
        public IActionResult DisplayBill(int orderId)
        {
            var bill = _orderRepository.GetBill(orderId);
            return View(bill);
        }

        [HttpGet]
        public IActionResult DisplayCustomersByOrderDate(DateTime orderDate)
        {
            var customers = _orderRepository.GetCustomersByOrderDate(orderDate);
            return View(customers);
        }

        [HttpGet]
        public IActionResult ShowCustomerWithHighestOrder()
        {
            var customer = _orderRepository.GetCustomerWithHighestOrder();
            return View(customer);
        }
    }
}