﻿using Project.BLL.Repositories.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Admin.Data.AdminPageVMs;
using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _pRep;
        CategoryRepository _cRep;

        public ProductController()
        {
            _cRep = new CategoryRepository();
            _pRep = new ProductRepository();
        }


        //Asagıdaki Action'da parametre olarak istenen id aslında CategoryID'sidir Product'in kendi id'si degildir...
        public ActionResult ListProducts(int? id)
        {
            AdminCategoryListPageVM apvm = new AdminCategoryListPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList(),
                Products = _pRep.GetAll()
            };
            return View(apvm);
        }

        public ActionResult AddProduct()
        {
            AdminCategoryListPageVM apvm = new AdminCategoryListPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList()
            };
            return View(apvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _pRep.Add(product);
            return RedirectToAction("ListProducts");
        }


        public ActionResult UpdateProduct(int id)
        {

            return View(_cRep.Find(id));
        }

        //Todo: VM refactoring unutulmasın...

        //Todo: Resim güncelleme
        [HttpPost]
       public ActionResult UpdateProduct(Product product)
        {
            _pRep.Update(product);
            return RedirectToAction("ListProducts");
        }


       public ActionResult DeleteProduct(int id)
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ListProducts");
        }
    }
}