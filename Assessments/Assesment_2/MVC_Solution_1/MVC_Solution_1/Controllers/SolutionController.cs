//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MVC_Solution_1.Models;

//namespace MVC_Solution_1.Controllers
//{
//    public class SolutionController : Controller
//    {
//        //private NorthwindEntities db = new NorthwindEntities();
//        private northwindEntities db = new northwindEntities();
//        // GET: Solution
//        public ActionResult Index()
//        {
//            var germanCustomers = db.Customers.Where(c => c.Country == "Germany").ToList();
//            return View(germanCustomers);
//            //return View();
//        }
//        public ActionResult CustomerWithOrder10248()
//        {
//            var customer = db.Customers.FirstOrDefault(c => c.Orders.Any(o => o.OrderID == 10248));
//            return View(customer);
//        }
//    }
//}



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