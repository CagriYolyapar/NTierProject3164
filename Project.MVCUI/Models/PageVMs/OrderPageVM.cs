using Project.ENTITIES.Models;
using Project.MVCUI.OuterRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.PageVMs
{
    public class OrderPageVM
    {
        //Refactor!!!!
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public PaymentRequestModel PaymentRM { get; set; }

       

    }
}