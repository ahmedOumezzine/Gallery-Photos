using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageTool.Models
{
    public class WebFile
    {
        [Key]
        public int Id { get; set; }
        public bool IsDefault { get; set; } // default gallery
        public bool IsActive { get; set; } // publish or not
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public int FileLength { get; set; }
        public string ContentType { get; set; }

        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        [ForeignKey("Gallery")]
        public int GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }

    }
}