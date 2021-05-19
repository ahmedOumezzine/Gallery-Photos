using System;
using System.Collections.Generic;


namespace Gallery_Photos.Models
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
