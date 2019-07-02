using MovieZone.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using MovieZone.Models.ViewModels;

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

        public ActionResult New() 
        {
            var memberShipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = memberShipTypes
            };

            return View("CustomerForm",newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id==0)
            {
            _context.Customers.Add(customer);
            }
            else
            {
                var customerToEdit = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);
                if (customerToEdit!=null)
                {
                    customerToEdit.Birthdate = customer.Birthdate;
                    customerToEdit.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customerToEdit.MembershipTypeId = customer.MembershipTypeId;
                    customerToEdit.Name = customer.Name;
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            var customerFormViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", customerFormViewModel);
        }
    }
}