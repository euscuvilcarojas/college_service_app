namespace BITCollege_EU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_StoreProcedure : DbMigration
    {
        public override void Up()
        {
            this.Sql(Properties.Resources.create_next_number);
        }
        
        public override void Down()
        {
            this.Sql(Properties.Resources.drop_next_number);
        }
    }
}
