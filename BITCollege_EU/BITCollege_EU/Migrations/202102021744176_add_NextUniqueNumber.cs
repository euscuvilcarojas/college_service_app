namespace BITCollege_EU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_NextUniqueNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NextUniqueNumbers",
                c => new
                    {
                        NextUniqueNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NextUniqueNumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NextUniqueNumbers");
        }
    }
}
