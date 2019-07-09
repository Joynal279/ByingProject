using ByingApplications.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ByingApplications.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fabric { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public IEnumerable<Category> categories { get; set; }
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        [DisplayName("Uploaded Image")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string Linker{get{
                return (Id != 0) ? "UpdateProduct" : "SaveProduct";
} }
    }
}