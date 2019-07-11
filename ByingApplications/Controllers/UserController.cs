using ByingApplications.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;

namespace ByingApplications.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminDashBoard()
        {
            
            var pro = _context.products.Include(r => r.Category);

            return View(pro);
        }

        public ActionResult StoreKeeperDashBoard()
        {

            return View();
        }
    }
}