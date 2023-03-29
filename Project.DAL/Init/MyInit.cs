using Bogus.DataSets;
using Project.COMMON.Tools;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Init
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin

            AppUser au = new AppUser();
            au.UserName = "cgr";
            au.Password = DantexCrypt.Crypt("123");
            au.Email = "cagri.yolyapar@gmail.com";
            au.Role = ENTITIES.Enums.UserRole.Admin;
            au.Active = true;
            context.AppUsers.Add(au);
            context.SaveChanges();




            #endregion



            #region NormalUsers


            for (int i = 0; i < 10; i++)
            {
                AppUser ap = new AppUser();
                ap.UserName = new Internet("tr").UserName();
                ap.Password = new Internet("tr").Password();
                ap.Email = new Internet("tr").Email();
                context.AppUsers.Add(ap);
            }


            context.SaveChanges();


            for (int i =2; i < 12; i++)
            {
                AppUserProfile apu = new AppUserProfile();
                apu.ID = i; //Birebir ilişki olduğundan dolayı üst tarafta olusturulan AppUser'ların ID'leri ile bunlar eşleşmek zorundadır...O yüzden döngünün iterasyonunu 2'den baslattık...
                apu.FirstName = new Name("tr").FirstName();
                apu.LastName = new Name("tr").LastName();
                context.Profiles.Add(apu);
            }
            context.SaveChanges();


            #endregion



            #region KategoriVeUrunBilgileri


            for (int i = 0; i < 10; i++)
            {

                Category c = new Category();


                c.CategoryName = new Commerce("tr").Categories(1)[0];
                c.Description = new Lorem("tr").Sentence(10);

                for (int j = 0; j < 30; j++)
                {
                    Product p = new Product();
                    p.ProductName = new Commerce("tr").ProductName();
                    p.UnitPrice = Convert.ToDecimal(new Commerce("tr").Price());
                    p.UnitsInStock = 100;
                    p.ImagePath = new Images().Nightlife();
                    c.Products.Add(p);
                    

                }


                context.Categories.Add(c);
                context.SaveChanges();




            }







            #endregion
        }
    }
}
