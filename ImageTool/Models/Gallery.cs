using System;
using System.Collections.Generic;


namespace ImageTool.Models
{

    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WebImageId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}
