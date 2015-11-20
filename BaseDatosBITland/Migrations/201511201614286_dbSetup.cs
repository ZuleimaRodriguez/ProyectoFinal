namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        Categorias = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        idProducto = c.Int(nullable: false, identity: true),
                        Personaje = c.String(),
                        Precio = c.Int(nullable: false),
                        TipoProductoTipo = c.String(),
                        CategoriaCategoria = c.String(),
                        Categoria_idCategoria = c.Int(),
                        TipoProducto_idTipo = c.Int(),
                    })
                .PrimaryKey(t => t.idProducto)
                .ForeignKey("dbo.Categorias", t => t.Categoria_idCategoria)
                .ForeignKey("dbo.TipoProductoes", t => t.TipoProducto_idTipo)
                .Index(t => t.Categoria_idCategoria)
                .Index(t => t.TipoProducto_idTipo);
            
            CreateTable(
                "dbo.Relacions",
                c => new
                    {
                        idRelacion = c.Int(nullable: false, identity: true),
                        FacturaidFactura = c.Int(nullable: false),
                        ProductoidProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRelacion)
                .ForeignKey("dbo.Productoes", t => t.ProductoidProducto, cascadeDelete: true)
                .ForeignKey("dbo.Facturas", t => t.FacturaidFactura, cascadeDelete: true)
                .Index(t => t.FacturaidFactura)
                .Index(t => t.ProductoidProducto);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tienda = c.String(),
                        NivelNivel = c.String(),
                        Direccion = c.String(),
                        Nivel_idNivel = c.Int(),
                    })
                .PrimaryKey(t => t.idCliente)
                .ForeignKey("dbo.Nivels", t => t.Nivel_idNivel)
                .Index(t => t.Nivel_idNivel);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFactura = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        ClienteidCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFactura)
                .ForeignKey("dbo.Clientes", t => t.ClienteidCliente, cascadeDelete: true)
                .Index(t => t.ClienteidCliente);
            
            CreateTable(
                "dbo.Nivels",
                c => new
                    {
                        idNivel = c.Int(nullable: false, identity: true),
                        Niveles = c.String(),
                    })
                .PrimaryKey(t => t.idNivel);
            
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        idTipo = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.idTipo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "TipoProducto_idTipo", "dbo.TipoProductoes");
            DropForeignKey("dbo.Clientes", "Nivel_idNivel", "dbo.Nivels");
            DropForeignKey("dbo.Facturas", "ClienteidCliente", "dbo.Clientes");
            DropForeignKey("dbo.Relacions", "FacturaidFactura", "dbo.Facturas");
            DropForeignKey("dbo.Productoes", "Categoria_idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Relacions", "ProductoidProducto", "dbo.Productoes");
            DropIndex("dbo.Facturas", new[] { "ClienteidCliente" });
            DropIndex("dbo.Clientes", new[] { "Nivel_idNivel" });
            DropIndex("dbo.Relacions", new[] { "ProductoidProducto" });
            DropIndex("dbo.Relacions", new[] { "FacturaidFactura" });
            DropIndex("dbo.Productoes", new[] { "TipoProducto_idTipo" });
            DropIndex("dbo.Productoes", new[] { "Categoria_idCategoria" });
            DropTable("dbo.TipoProductoes");
            DropTable("dbo.Nivels");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Relacions");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
