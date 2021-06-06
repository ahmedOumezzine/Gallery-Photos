using Gallery_Photos.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Gallery_Photos.Controllers
{
    public class DownloadFileController : Controller
    {  
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Any, VaryByParam = "Id;t")]
        public ActionResult GetImage(int Id = 0, int t = 0)
        {
            if (Id == 0)
            {
                return File("~/images/NoImage.png", "image/png");
            }

            DefaultContext db = new DefaultContext();

            var model = db.WebFiles.Find(Id);

            if (model != null)
            {
                if (t != 0)
                {
                    if(model.FilePath==null)
                        return File("~/images/NoImage.png", "image/png");
                    else
                    {
                        byte[] img = ImageTool.Tool.getThumbNail(Server.MapPath("~/")+"/"+model.FilePath, t);
                        if (img == null)
                            return File("~/images/NoImage.png", "image/png");
                        else
                        return File(img, model.ContentType, "thumb_" + model.FileName);
                    }
                
                }

                return File(model.FilePath, model.ContentType, model.FileName);
            }
            else
            {
                return HttpNotFound();
            }
        }
         
    }
}