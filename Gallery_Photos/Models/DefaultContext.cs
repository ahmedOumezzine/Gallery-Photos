using ImageTool.Models;
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

        public virtual DbSet<WebFile> WebFiles { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
    }


}