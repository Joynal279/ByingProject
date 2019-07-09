using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByingApplications.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fabric { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ImageFile { get; set; }
    }
}