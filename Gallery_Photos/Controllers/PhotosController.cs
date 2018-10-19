using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{
    public class PhotosController : Controller
    {
        // GET: Photos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Picture picture)
        {
            return View();
        }
    }
}