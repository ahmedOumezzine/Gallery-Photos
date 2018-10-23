using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Gallery_Photos.Models
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base("DefaultContext")
        {
        }

        public DbSet<Picture> Pictures { get; set; }
    }

    public class Picture
    {
        [Key]
        public Guid ID { get; set; }

        public String name { get; set; }
        public Byte[] images { get; set; }
        public DateTime CreateDate { get; set; }
    }
}