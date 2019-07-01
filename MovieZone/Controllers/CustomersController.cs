using MovieZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieZone.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "Customer 1"},
                new Customer(){ Id = 2, Name = "Customer 2"}
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "Customer 1"},
                new Customer(){ Id = 2, Name = "Customer 2"}
            };

            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}