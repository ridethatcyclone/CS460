using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class MenuCategoriesVM
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public int ProductSubcategoryID { get; set; }
        public string ProductSubcategoryName { get; set; }
    }
}