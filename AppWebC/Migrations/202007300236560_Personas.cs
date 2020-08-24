namespace AppWebC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Personas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "id_usuario", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "id_usuario", c => c.Int(nullable: false));
        }
    }
}
