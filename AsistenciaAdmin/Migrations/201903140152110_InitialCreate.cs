namespace AsistenciaAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        NombreAula = c.String(),
                    })
                .PrimaryKey(t => t.AulaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aulas");
        }
    }
}
