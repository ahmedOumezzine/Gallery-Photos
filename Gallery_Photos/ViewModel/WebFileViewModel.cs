using Gallery_Photos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Gallery_Photos.ViewModel
{
    public class WebFileViewModel
    {
        public static WebFile getEntityModel(HttpPostedFileBase file)
        {
            WebFile webfile = new WebFile();

            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] data = target.ToArray();

            webfile.Data = data;
            webfile.ContentType = file.ContentType;
            webfile.FileExt = Path.GetExtension(file.FileName); 
            webfile.FileLength = file.ContentLength;
            webfile.FileName = file.FileName;
            webfile.IsActive = true;
            webfile.UpdateDate = DateTime.Now;

            return webfile;
        }
    }
}