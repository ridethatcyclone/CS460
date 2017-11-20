using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class MenuCategoriesVM
    {
        public IEnumerable<ProductCategory> ProductCategoryID { get; set; }
        public IEnumerable<ProductCategory> ProductCategoryName { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategoryID { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategoryName { get; set; }
        public IEnumerable<Product> Name { get; set; }
        public IEnumerable<Product> ProductID { get; set; }
        public IEnumerable<Product> Color { get; set; }
        public IEnumerable<Product> ListPrice { get; set; }
    }
}