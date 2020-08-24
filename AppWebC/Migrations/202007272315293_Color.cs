namespace AppWebC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Color : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre_color = c.String(nullable: false),
                        color = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 20),
                        direccion = c.String(nullable: false),
                        telefono = c.String(nullable: false),
                        fecha_nacimiento = c.DateTime(nullable: false),
                        edad = c.Int(),
                        id_color = c.Int(nullable: false),
                        id_usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persona");
            DropTable("dbo.Color");
        }
    }
}
