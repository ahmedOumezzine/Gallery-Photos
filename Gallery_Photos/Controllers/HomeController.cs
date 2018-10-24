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
        public ActionResult Index2()
        {
            var list = DefaultContext.Pictures.ToList();
            return View(list);
        }
        public ActionResult Index3()
        {
            var list = DefaultContext.Pictures.ToList();
            return View(list);
        }



        [HttpGet]
        public FileResult GetImage(string id)
        {
            Models.Picture picture = DefaultContext.Pictures.Where(x => x.name == id).SingleOrDefault();
            byte[] fileContents = picture.images;
            string contentType = "image/jpeg";
            int identificador = GC.GetGeneration(fileContents);
            GC.Collect(identificador, GCCollectionMode.Forced);

            identificador = GC.GetGeneration(picture);
            GC.Collect(identificador, GCCollectionMode.Forced);
            ////Force garbage collection.
            //GC.Collect();
            //// Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
         

            return File(ImageCompress.Decompress(fileContents), contentType);
        }

        public FileResult GetImage2(string id)
        {
            byte[] fileContents = DefaultContext.Pictures.Where(x => x.name == id).SingleOrDefault().images;
            string contentType = "image/jpeg";
            //Force garbage collection.
            //GC.Collect();
            // Wait for all finalizers to complete before continuing.
            //GC.WaitForPendingFinalizers();
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