using Project.ENTITIES.Models;
using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Areas.Admin.Data.AdminPageVMs
{
    public class AdminCategoryListPageVM
    {
        public List<AdminCategoryVM> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}