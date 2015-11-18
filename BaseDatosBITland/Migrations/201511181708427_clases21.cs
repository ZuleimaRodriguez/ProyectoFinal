namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clases21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IdFactura = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFactura)
                .ForeignKey("dbo.Clientes", t => t.id, cascadeDelete: true)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Nivels",
                c => new
                    {
                        IdNivel = c.Int(nullable: false, identity: true),
                        nivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdNivel);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Personaje = c.String(),
                        categoria = c.String(),
                        Tipo = c.String(),
                        precio = c.Int(nullable: false),
                        Foto = c.String(),
                        TipoProducto_IdTipo = c.Int(),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.TipoProductoes", t => t.TipoProducto_IdTipo)
                .Index(t => t.TipoProducto_IdTipo);
            
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        IdTipo = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.IdTipo);
            
            AddColumn("dbo.Clientes", "Nivel_IdNivel", c => c.Int());
            AlterColumn("dbo.Clientes", "Nivel", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "Nivel_IdNivel");
            AddForeignKey("dbo.Clientes", "Nivel_IdNivel", "dbo.Nivels", "IdNivel");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "TipoProducto_IdTipo", "dbo.TipoProductoes");
            DropForeignKey("dbo.Clientes", "Nivel_IdNivel", "dbo.Nivels");
            DropForeignKey("dbo.Facturas", "id", "dbo.Clientes");
            DropIndex("dbo.Productoes", new[] { "TipoProducto_IdTipo" });
            DropIndex("dbo.Facturas", new[] { "id" });
            DropIndex("dbo.Clientes", new[] { "Nivel_IdNivel" });
            AlterColumn("dbo.Clientes", "Nivel", c => c.String());
            DropColumn("dbo.Clientes", "Nivel_IdNivel");
            DropTable("dbo.TipoProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Nivels");
            DropTable("dbo.Facturas");
        }
    }
}
