using Gallery_Photos.Models;
using ImageTool.Models;
using ImageTool.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery_Photos.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _List()
        {
            DefaultContext db = new DefaultContext();
            var list = db.Galleries.OrderBy(x => x.CreatedDate)
                        .Select(x => new ImageList
                        {
                            Id = x.Id,
                            IsActive = x.IsActive, 
                            WebImageId = x.Files.Where(y=>y.IsDefault==true).FirstOrDefault().Id,
                            Title = x.Title
                        }).ToList();

            return PartialView(list);
        }

        public ActionResult Create()
        {
            ImageEditorViewModel vm = new ImageEditorViewModel();
            ViewBag.Action = "Create";
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ImageEditorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DefaultContext db = new DefaultContext();

                    var fileModel = WebFileViewModel.getEntityModel(model.FileImage, Server.MapPath("~/Uploads/"));
                    fileModel.IsDefault = true;
                    var entity = ImageEditorViewModel.getEnityModel(model);
                    entity.Files = new List<WebFile>();
                    entity.Files.Add(fileModel);
                    entity.CreatedDate = DateTime.UtcNow;
                    db.Galleries.Add(entity);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult Edit(int Id)
        {
            DefaultContext db = new DefaultContext();
            var Item = db.Galleries.Include("Files").Where(x => x.Id== Id).FirstOrDefault();
            ImageEditorViewModel vm = ImageEditorViewModel.getEnity(Item);
            ViewBag.Action = "Edit";
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ImageEditorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DefaultContext db = new DefaultContext();
                    var Item = db.Galleries.Include("Files").Where(x => x.Id == model.Id).FirstOrDefault();
                    if (model.FileImage != null)
                    {     
                        var path = Server.MapPath("~/Uploads/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        var File = Item.Files.Where(x => x.IsDefault == true).FirstOrDefault();
                        model.FileImage.SaveAs(path + Path.GetFileName(model.FileImage.FileName));
                        File.FilePath = "/Uploads/" + Path.GetFileName(model.FileImage.FileName);
                        db.Entry(File).State = System.Data.Entity.EntityState.Modified;
                    }
                    Item.Title = model.Caption;
                    db.Entry(Item).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            DefaultContext db = new DefaultContext();
            var Item = db.Galleries.Include("Files").Where(x => x.Id == Id).FirstOrDefault();
            if (Item != null)
            {
                if (Item.Files != null)
                {
                    foreach(var File in Item.Files)
                    {
                        System.IO.File.Delete(Server.MapPath("/") + "/" + File.FilePath);
                    }
                    db.WebFiles.RemoveRange(Item.Files);


                }
                db.Entry(Item).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}