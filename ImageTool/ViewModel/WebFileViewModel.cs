using ImageTool.Models;
using System;
using System.IO;
using System.Web;

namespace ImageTool.ViewModel
{
    public class WebFileViewModel
    {
        public static WebFile getEntityModel(HttpPostedFileBase file, string path)
        {
            WebFile webfile = new WebFile(); 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            file.SaveAs(path + Path.GetFileName(file.FileName)); 
            webfile.FilePath = "/Uploads/" + Path.GetFileName(file.FileName);
            webfile.ContentType = file.ContentType;
            webfile.FileExt = Path.GetExtension(file.FileName);
            webfile.FileLength = file.ContentLength;
            webfile.FileName = file.FileName;
            webfile.IsActive = true;
            webfile.CreatedDate = DateTime.Now;
            webfile.UpdatedDate = DateTime.Now;

            return webfile;
        }
    }
}