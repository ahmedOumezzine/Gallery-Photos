using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageTool.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public System.DateTime CreatedDate { get; set; }
         
        public virtual ICollection<WebFile> Files { get; set; }
  }
}