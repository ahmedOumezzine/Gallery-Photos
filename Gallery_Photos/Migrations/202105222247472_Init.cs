namespace Gallery_Photos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDefault = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        FileName = c.String(),
                        FileExt = c.String(),
                        FileLength = c.Int(nullable: false),
                        ContentType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebFiles", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.WebFiles", new[] { "GalleryId" });
            DropTable("dbo.WebFiles");
            DropTable("dbo.Galleries");
        }
    }
}
