namespace BaseDatosBITland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corregido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "TipoidTipo", c => c.String());
            AddColumn("dbo.Productoes", "CategoriaidCategoria", c => c.String());
            DropColumn("dbo.Productoes", "TipoProductoTipo");
            DropColumn("dbo.Productoes", "CategoriaCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "CategoriaCategoria", c => c.String());
            AddColumn("dbo.Productoes", "TipoProductoTipo", c => c.String());
            DropColumn("dbo.Productoes", "CategoriaidCategoria");
            DropColumn("dbo.Productoes", "TipoidTipo");
        }
    }
}
