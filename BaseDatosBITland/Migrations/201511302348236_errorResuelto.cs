namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorResuelto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "Categoria_idCategoria", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "Categoria_idCategoria" });
            DropColumn("dbo.Productoes", "CategoriaidCategoria");
            RenameColumn(table: "dbo.Productoes", name: "Categoria_idCategoria", newName: "CategoriaidCategoria");
            AlterColumn("dbo.Productoes", "TipoidTipo", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "CategoriaidCategoria", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "CategoriaidCategoria", c => c.Int(nullable: false));
            CreateIndex("dbo.Productoes", "CategoriaidCategoria");
            AddForeignKey("dbo.Productoes", "CategoriaidCategoria", "dbo.Categorias", "idCategoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "CategoriaidCategoria", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "CategoriaidCategoria" });
            AlterColumn("dbo.Productoes", "CategoriaidCategoria", c => c.Int());
            AlterColumn("dbo.Productoes", "CategoriaidCategoria", c => c.String());
            AlterColumn("dbo.Productoes", "TipoidTipo", c => c.String());
            RenameColumn(table: "dbo.Productoes", name: "CategoriaidCategoria", newName: "Categoria_idCategoria");
            AddColumn("dbo.Productoes", "CategoriaidCategoria", c => c.String());
            CreateIndex("dbo.Productoes", "Categoria_idCategoria");
            AddForeignKey("dbo.Productoes", "Categoria_idCategoria", "dbo.Categorias", "idCategoria");
        }
    }
}
