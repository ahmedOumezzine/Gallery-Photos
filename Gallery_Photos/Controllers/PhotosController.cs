using Gallery_Photos.Models;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{
    public class PhotosController : Controller
    {
        DefaultContext DefaultContext = new DefaultContext();

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
        public ActionResult Add(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    Models.Picture picture = new Picture();
                    picture.ID = Guid.NewGuid();
                    picture.images = ImageCompress.Compress(data); // 252551
                    picture.name = file.FileName.Replace(".","") + ".jpg";
                    picture.CreateDate = DateTime.Now;
                  var item=   DefaultContext.Pictures.Add(picture);
                    DefaultContext.SaveChanges();
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                     ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View() ;
        }
       
    }
}