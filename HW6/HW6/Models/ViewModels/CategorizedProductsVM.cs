using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class CategorizedProductsVM
    {
        public IEnumerable<ProductCategory> CategoryList { get; set; }
        public IEnumerable<ProductSubcategory> SubcategoryList { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
    }
}