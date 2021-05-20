using System;
using System.Collections.Generic;

namespace ImageTool.Models
{


    public class WebFile
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public int FileLength { get; set; }
        public string ContentType { get; set; }
    }
}
