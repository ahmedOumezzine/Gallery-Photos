using Gallery_Photos.Models;
using ImageTool.Models;
using ImageTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{
    public class GalleryAdminController : Controller
    {
        // GET: GalleryAdmin
        public ActionResult Index(int Id)
        {
            return View(Id);
        }

        public ActionResult Create(int Id)
        {
            ImageEditorViewModel vm = new ImageEditorViewModel();
            ViewBag.Action = "Create";
            ViewBag.Id = Id;
            return PartialView(vm);
        }

        [HttpPost]
        public ActionResult Create(ImageEditorViewModel model,int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DefaultContext db = new DefaultContext(); 

                    var fileModel = WebFileViewModel.getEntityModel(model.FileImage, Server.MapPath("~/Uploads/"));
                    fileModel.IsDefault = false;
                    fileModel.GalleryId = Id;
                    db.WebFiles.Add(fileModel);
                    db.SaveChanges();

                   
                    return Json(new { success = true, Caption = model.Caption });
                }

                return Json(new { success = false, ValidationMessage = "Please check validation messages" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ExceptionMessage = "Some error here" });
            }
        }

        public ActionResult _List(int Id)
        {
            DefaultContext db = new DefaultContext();
            var list = db.WebFiles.Where(x=>x.GalleryId==Id && x.IsDefault==false).OrderBy(x => x.CreatedDate)
                        .Select(x => new ImageList
                        {
                            Id = x.Id,
                            IsActive = x.IsActive,
                            WebImageId = x.Id,
                            Title = x.FileName
                        }).ToList();

            return PartialView(list);
        }
        

        [HttpPost]
        public JsonResult ChangeActive(int Id, bool status)
        {
            DefaultContext db = new DefaultContext();
            var entity = db.Galleries.Find(Id);
            entity.IsActive = status;
            db.SaveChanges();

            return Json(entity.Title);
        }
    }
}