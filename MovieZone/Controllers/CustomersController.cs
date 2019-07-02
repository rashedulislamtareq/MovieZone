using MovieZone.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace MovieZone.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x=>x.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x=>x.MembershipType).FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}