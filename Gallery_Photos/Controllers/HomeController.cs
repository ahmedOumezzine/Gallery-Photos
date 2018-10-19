using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{

    public class HomeController : Controller
    {

         public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public FileResult GetImage(string id)
        {
            byte[] fileContents = System.IO.File.ReadAllBytes(@"C:\Users\AhmedOumezzine\source\Repos\Gallery_Photos\Gallery_Photos\Content\style\images\art\tg5-7.jpeg");
            string contentType = "image/jpeg";
            //Force garbage collection.
            GC.Collect();
            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
            return File(fileContents, contentType);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}