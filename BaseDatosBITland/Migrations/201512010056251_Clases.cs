namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        Cate = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        idProducto = c.Int(nullable: false, identity: true),
                        Personaje = c.String(),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        CategoriaidCategoria = c.Int(nullable: false),
                        TipoProductoidTipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProducto)
                .ForeignKey("dbo.Categorias", t => t.CategoriaidCategoria, cascadeDelete: true)
                .ForeignKey("dbo.TipoProductoes", t => t.TipoProductoidTipo, cascadeDelete: true)
                .Index(t => t.CategoriaidCategoria)
                .Index(t => t.TipoProductoidTipo);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFactura = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Tienda_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idFactura)
                .ForeignKey("dbo.Clientes", t => t.Tienda_idCliente)
                .Index(t => t.Tienda_idCliente);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        Tienda = c.String(),
                        Nombre = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.idCliente);
            
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        idTipo = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.idTipo);
            
            CreateTable(
                "dbo.FacturaProductoes",
                c => new
                    {
                        Factura_idFactura = c.Int(nullable: false),
                        Producto_idProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Factura_idFactura, t.Producto_idProducto })
                .ForeignKey("dbo.Facturas", t => t.Factura_idFactura, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.Producto_idProducto, cascadeDelete: true)
                .Index(t => t.Factura_idFactura)
                .Index(t => t.Producto_idProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "TipoProductoidTipo", "dbo.TipoProductoes");
            DropForeignKey("dbo.Productoes", "CategoriaidCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Facturas", "Tienda_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.FacturaProductoes", "Producto_idProducto", "dbo.Productoes");
            DropForeignKey("dbo.FacturaProductoes", "Factura_idFactura", "dbo.Facturas");
            DropIndex("dbo.FacturaProductoes", new[] { "Producto_idProducto" });
            DropIndex("dbo.FacturaProductoes", new[] { "Factura_idFactura" });
            DropIndex("dbo.Facturas", new[] { "Tienda_idCliente" });
            DropIndex("dbo.Productoes", new[] { "TipoProductoidTipo" });
            DropIndex("dbo.Productoes", new[] { "CategoriaidCategoria" });
            DropTable("dbo.FacturaProductoes");
            DropTable("dbo.TipoProductoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
