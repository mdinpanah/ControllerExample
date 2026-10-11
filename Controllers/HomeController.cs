using Microsoft.AspNetCore.Mvc;
using ControllerExample.Models;

namespace ControllerExample.Controllers
{
    public class HomeController :Controller
    {
        [Route("sayhello")]
        [Route("sayhello2")]
    
        public string Method1()
        {
            return "hello from method1";
        }
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
           // return new ContentResult()   { Content = "hello from Home", ContentType = "text/plain" };
            return Content("hello from Home", "text/plain");
          //  return Content("<h1> Welcome</h1><h2> hello from Home</h2>", "text/html");
        }

        [Route("about-us")]
        public string About()
        {  
            return "hello from about page ";
        }

     //   [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        [Route(@"contact-us/{mobile:regex(^\d{{10}}$)}")]
        public string Contact()
        {
                  return "hello from Contact page  ";
        }

        [Route("person")]
        public JsonResult Person()
        {
            //return "{\"FirstName\":\"Marziyeh\"}";
            //return @"{""FirstName"":""Marziyeh""}";
            Person p = new Person() {Id=Guid.NewGuid (),FirstName="Marziyeh" ,Lastname="Dinpanah" ,Age= 43   }; 
          //  return new JsonResult(p);
          return Json(p);
        }

        [Route("file-download")]
        public VirtualFileResult Filedownload()
        {
          //    return new VirtualFileResult("/a.pdf", "application/pdf");
            return File("/a.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult Filedownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\dinpanah.MSG\Desktop\Desk1\Desktop-old\factor\b.pdf", "application/pdf");
            return  PhysicalFile(@"C:\Users\dinpanah.MSG\Desktop\Desk1\Desktop-old\factor\b.pdf", "application/pdf");
        }



        [Route("file-download3")]
        public FileContentResult Filedownload3()
        {
            Byte[] b = System.IO.File.ReadAllBytes(@"C:\Users\dinpanah.MSG\Desktop\Desk1\Desktop-old\factor\c.pdf");
            //return new FileContentResult(b, "application/pdf");
             return File(b, "application/pdf");
        }
    }
}
 