using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Solution_1.Models;

namespace MVC_Solution_1.Controllers
{
    public class CodeController : Controller
    {
        private northwindEntities NE = new northwindEntities();
        public ActionResult AllCustomers()
        {
            var customers = NE.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }
        public ActionResult CustomerDetails()
        {
            var customerdetails = NE.Customers
                .Where(c => c.Orders.Any(o => o.OrderID == 10248))
                .ToList();
            return View(customerdetails);
        }

        public ActionResult Index()
        {
            return View();
        }

    }

}