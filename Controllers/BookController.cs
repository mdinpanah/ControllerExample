using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    public class BookController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
           
            if (!Request.Query.ContainsKey("BookId"))
            {
                Response.StatusCode = 400;
                return Content("Book Id is not supplied");
            } 
            if    (string.IsNullOrEmpty( Convert.ToString(Request.Query["BookId"])))
            {
                Response.StatusCode = 400;
                return Content("Book Id can nto be null or empty"); 
            }

            int bookid = Convert.ToInt32(Request.Query["BookId"]) ; 
           if (bookid<=0) 
            {
                Response.StatusCode = 400;
                return Content("Book Id can nto be less than or equal zero ");
            }
            if (bookid >1000)

            {
                Response.StatusCode = 400;
                return Content("Book Id can nto be greater than 1000  ");
            }
            if ( Convert.ToBoolean( Request.Query["isloggedin"])==false)

            {
                Response.StatusCode = 401;
                return Content("User must be authenticated  ");
            }
                return File("/a.pdf", "application/pdf"); 
        }
    }
}
