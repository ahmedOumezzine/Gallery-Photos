using Gallery_Photos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{
    public class HomeController : Controller
    {
        Models.DefaultContext DefaultContext = new Models.DefaultContext();

        public ActionResult Index()
        {
            var list = DefaultContext.Pictures.ToList();
            return View(list);
        }

        [HttpGet]
        public FileResult GetImage(string id)
        {
            byte[] fileContents = DefaultContext.Pictures.Where(x=>x.name==id).SingleOrDefault().images;
            string contentType = "image/jpeg";
            //Force garbage collection.
            GC.Collect();
            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
            return File(ImageCompress.Decompress(fileContents), contentType);
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