using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.ShoppingTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetim;

        public Cart()
        {
            _sepetim = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetim.Values.ToList();
            }
        }

        public void SepeteEkle(CartItem item)
        {
            if (_sepetim.ContainsKey(item.ID))
            {
                _sepetim[item.ID].Amount++;
                return;
            }

            _sepetim.Add(item.ID, item);
        }


        public void SepettenCikar(int id)
        {
            if (_sepetim[id].Amount > 1)
            {
                _sepetim[id].Amount--;
                return;
            }
            _sepetim.Remove(id);
        }

        public decimal TotalPrice
        {
            get
            {
                return _sepetim.Sum(x => x.Value.SubTotal);
            }
        }
    }
}