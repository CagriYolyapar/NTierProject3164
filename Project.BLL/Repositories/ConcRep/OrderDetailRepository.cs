using Project.BLL.Repositories.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories.ConcRep
{
    public class OrderDetailRepository:BaseRepository<OrderDetail>
    {

        public override void Update(OrderDetail item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            OrderDetail toBeUpdated = Find(item.ProductID, item.OrderID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }


        /*
         * 
         * ProductVM
         * 
         * 
         * List<string> CategoryNames
         * 
         * 
         
         foreach(CategoryProduct item in _db.Products.CategoryProducts)
        {

             CategoryNames.Add( _db.Categories.Find(item.CategoryID).CategoryName)

        }
         
         
         
         
         
         
         
         
         */


    }
}
