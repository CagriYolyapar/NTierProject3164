using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.PageVMs
{
    public class PaginationVM
    {
        //Refactor yaparken ProductVM olarak degiştirmeyi sakın unutmayın
        public IPagedList<Product> PagedProducts { get; set; }
        

        public List<Category> Categories { get; set; }
        public Product Product { get; set; }

    }
}