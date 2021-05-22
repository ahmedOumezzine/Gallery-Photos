using ImageTool.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageTool.ViewModel
{
    public class ImageEditorViewModel
    {
        public int Id { get; set; }

        
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase FileImage { get; set; }
        public int FileId { get; set; }
        public string FilePath { get; set; }

        public static Gallery getEnityModel(ImageEditorViewModel model)
        {
            return new Gallery
            {
                IsActive = true,
                Title = model.Caption, 
            };
        }
        public static ImageEditorViewModel getEnity(Gallery model)
        {
            return new ImageEditorViewModel
            {
                Id = model.Id,
                Caption = model.Title,
                FileId = model.Files!=null ? model.Files.Where(x=>x.IsDefault==true).FirstOrDefault().Id:0, 
                FilePath = model.Files!=null ? model.Files.Where(x => x.IsDefault == true).FirstOrDefault().FilePath:"", 
            };
        }
    }

    public class ImageList
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? OrderNo { get; set; }
        public string Title { get; set; }
        public int WebImageId { get; set; }
    }
}