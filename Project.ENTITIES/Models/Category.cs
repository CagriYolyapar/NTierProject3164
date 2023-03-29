using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Products = new List<Product>(); //bu ifade , MyInit class'ında henüz EF tetiklenmeden , yani işlemlerimiz saf bir şekilde RAM'de başladığında bu Category class'ının Products isimli Property'si null gelmesin diye yapılmıstır...Cünkü bir Category instance'i alındığında onun Products özelliğinin instance'lanmasını hep isteriz...AKsi halde Ram'de yaptıgımız işlemlerde ilgili Category instance'inin Products özelligini erişip oradan bir işlem yapmaya calısırsak NullReferenceException hatası alırız....

            //Unutmayın ki EF işlemleri baslamadan önce siz klasik bir şekilde Ram'de calısıyorsunuz...Yani EF'in virtual ile Lazy Loading ile birlikte SQL ilişkisini anlamasını bekleyeceğiniz alan daha baslamamıstır...
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }


        //Relational Properties
        public virtual List<Product> Products { get; set; }

    }
}
