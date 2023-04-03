using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.CustomTools
{
    public static class ImageUploader
    {
        //Geriye string deger döndüren metodumuz resmin yolunu döndürecek veya resim yükleme ile ilgili bir sorun varsa onun kodunu döndürecek "C:/Images....", "1" ,"2"

        //HttpPostedFileBase => 

        public static string UploadImage(string serverPath,HttpPostedFileBase file,string name)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray =  file.FileName.Split('.');    //"starwars.uzaygemileri.stardestroyer.jpg"...burada Split metodu sayesinde ilgili yapının uzantısının da iceride bulundugu bir string dizisi almıs olduk...SPlit metodu belirttiginiz char karakterinden metni bölerek size bir array sunar...

                string extension = fileArray[fileArray.Length - 1].ToLower(); //Dosya uzantısını yakalarak kücük harflere cevirdik...

                string fileName = $"{uniqueName}.{name}.{extension}"; //normal şartlarda biz burada Guid kullandıgımız icin asla bir dosya ismi aynı olmayacaktır...Lakin siz Guid kullanmazsanız(sadece kullanıyıa yüklemek istedigi dosyanın ismini girdirmek isterseniz) Böyle bir durumda aynı isimde dosya upload'u mümkün hale gelecektir...Dolayısıyla öyle bir durumda ek olarak bir kontrol yapmanız gerekecektir...Tabii ki böyle bir senaryo olsun veya olmasın önce extension kontrol edilmelidir...Bahsettigimiz ek kontrol daha sonra yapılmalıdır...



                if(extension =="jpg" || extension == "gif"||extension == "png")
                {
                    //Eger dosya ismi zaten varsa 
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //Ancak GUid kullandıgımız icin bu acıdan zaten güvendeyiz(dosya zaten var kodu)
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath+fileName);
                        file.SaveAs(filePath);
                        return $"{serverPath}{fileName}";
                    }
                }
                else
                {
                    return "2"; //Secilen dosya bir resim degildir kodu
                }


            }

            else
            {
                return "3"; //Dosya bos kodu
            }
        }
    }
}