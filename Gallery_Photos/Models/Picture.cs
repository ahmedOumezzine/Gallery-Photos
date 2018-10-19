using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gallery_Photos.Models
{
    public class Picture
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public Byte[] images { get; set; }
        public DateTime CreateDate { get; set; }

    }
}