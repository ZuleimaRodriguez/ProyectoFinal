namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relacions", "FacturaidFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteidCliente", "dbo.Clientes");
            DropIndex("dbo.Relacions", new[] { "FacturaidFactura" });
            DropIndex("dbo.Facturas", new[] { "ClienteidCliente" });
            RenameColumn(table: "dbo.Facturas", name: "ClienteidCliente", newName: "ClienteidCliente_idCliente");
            AddColumn("dbo.Productoes", "Factura_idFactura", c => c.Int());
            AddColumn("dbo.Facturas", "Fecha", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facturas", "ClienteidCliente_idCliente", c => c.Int());
            CreateIndex("dbo.Productoes", "Factura_idFactura");
            CreateIndex("dbo.Facturas", "ClienteidCliente_idCliente");
            AddForeignKey("dbo.Productoes", "Factura_idFactura", "dbo.Facturas", "idFactura");
            AddForeignKey("dbo.Facturas", "ClienteidCliente_idCliente", "dbo.Clientes", "idCliente");
            DropColumn("dbo.Facturas", "Cantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Cantidad", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facturas", "ClienteidCliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Productoes", "Factura_idFactura", "dbo.Facturas");
            DropIndex("dbo.Facturas", new[] { "ClienteidCliente_idCliente" });
            DropIndex("dbo.Productoes", new[] { "Factura_idFactura" });
            AlterColumn("dbo.Facturas", "ClienteidCliente_idCliente", c => c.Int(nullable: false));
            DropColumn("dbo.Facturas", "Fecha");
            DropColumn("dbo.Productoes", "Factura_idFactura");
            RenameColumn(table: "dbo.Facturas", name: "ClienteidCliente_idCliente", newName: "ClienteidCliente");
            CreateIndex("dbo.Facturas", "ClienteidCliente");
            CreateIndex("dbo.Relacions", "FacturaidFactura");
            AddForeignKey("dbo.Facturas", "ClienteidCliente", "dbo.Clientes", "idCliente", cascadeDelete: true);
            AddForeignKey("dbo.Relacions", "FacturaidFactura", "dbo.Facturas", "idFactura", cascadeDelete: true);
        }
    }
}
