using ByingApplications.Models;
using ByingApplications.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByingApplications.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Product
        public ActionResult Index()
        {
            var pro = _context.products.Include(r => r.Category).ToList();
            return View(pro);
        }
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Heading = "Add a Product";
            var viewmodel = new ProductViewModel()
            {
                categories = _context.categories
            };
            return View(viewmodel);
           
        }
        [HttpPost]
        public ActionResult SaveProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(productViewModel.ImageFile.FileName);
                string extension = Path.GetExtension(productViewModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString() + extension;
                productViewModel.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                //productViewModel.ImageFile.SaveAs(fileName);
                var addedDate = DateTime.Now;
                var addedBy = User.Identity.Name;


                var pro = new Product()
                {
                    Name = productViewModel.Name,
                    Color = productViewModel.Color,
                    Description = productViewModel.Description,
                    Fabric = productViewModel.Fabric,
                    Quantity = productViewModel.Quantity,
                    UnitPrice = productViewModel.UnitPrice,
                    AddedBy = addedBy,
                    AddedDate = addedDate,
                    CategoryId = productViewModel.CategoryId,
                    ImageFile = productViewModel.ImagePath
                };
                _context.products.Add(pro);
                _context.SaveChanges();
                return View("Index");
            }

            else
            {
                ViewBag.message = "fil up the form";
                return View("Create");
            }
            

        }
        public ActionResult Edit(int id)
        {
            var pro = _context.products.Single(r => r.Id==id);
            ViewBag.Heading = "Edit a Product";
            var item = new ProductViewModel
            {
                Id = pro.Id,
                categories = _context.categories.ToList(),
                Name= pro.Name,
                Color= pro.Color,
                Description= pro.Description,
                Fabric= pro.Fabric,
                Quantity= pro.Quantity,
                UnitPrice= pro.UnitPrice,
                ImagePath= pro.ImageFile,
                CategoryId=pro.CategoryId
                
               



            };
            return View("Create", item);
        }

        public ActionResult UpdateProduct(ProductViewModel viewModel)
        {
            var oldProduct = _context.products.Single(r=>r.Id==viewModel.Id);

            oldProduct.Id = viewModel.Id;
            oldProduct.Name = viewModel.Name;
            oldProduct.Color = viewModel.Color;
            oldProduct.Description = viewModel.Description;
            oldProduct.Fabric = viewModel.Fabric;
            oldProduct.Quantity = viewModel.Quantity;
            oldProduct.UnitPrice = viewModel.UnitPrice;
            oldProduct.CategoryId = viewModel.CategoryId;
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");

        }
    }
}