namespace PonosData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggggggggggggg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campanies",
                c => new
                    {
                        campanyId = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        activitySector = c.String(),
                        category = c.String(),
                        Solde = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.campanyId);
            
            CreateTable(
                "dbo.Trainingonlines",
                c => new
                    {
                        trainingonlineId = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        price = c.Double(nullable: false),
                        description = c.String(),
                        nbReservation = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        campanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.trainingonlineId)
                .ForeignKey("dbo.Campanies", t => t.campanyId, cascadeDelete: true)
                .Index(t => t.campanyId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        titre = c.String(maxLength: 50),
                        nbPage = c.Int(nullable: false),
                        dateAjout = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        trainingonlineId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Trainingonlines", t => t.trainingonlineId)
                .Index(t => t.trainingonlineId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        trainingonline = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        reservationId = c.Int(nullable: false, identity: true),
                        etat = c.String(),
                        dateReservation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.trainingonline, t.UserId, t.reservationId })
                .ForeignKey("dbo.Trainingonlines", t => t.trainingonline)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.trainingonline)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        firstnamePerson = c.String(),
                        lastnamePerson = c.String(),
                        AdressPerson = c.String(),
                        EmailPerson = c.String(),
                        TelephonPerson = c.Int(nullable: false),
                        solde = c.Double(nullable: false),
                        PasswordPerson = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        CommentaireId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        trainingonlineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentaireId)
                .ForeignKey("dbo.Trainingonlines", t => t.trainingonlineId, cascadeDelete: true)
                .Index(t => t.trainingonlineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "trainingonlineId", "dbo.Trainingonlines");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "trainingonline", "dbo.Trainingonlines");
            DropForeignKey("dbo.Courses", "trainingonlineId", "dbo.Trainingonlines");
            DropForeignKey("dbo.Trainingonlines", "campanyId", "dbo.Campanies");
            DropIndex("dbo.Commentaires", new[] { "trainingonlineId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Reservations", new[] { "trainingonline" });
            DropIndex("dbo.Courses", new[] { "trainingonlineId" });
            DropIndex("dbo.Trainingonlines", new[] { "campanyId" });
            DropTable("dbo.Commentaires");
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Courses");
            DropTable("dbo.Trainingonlines");
            DropTable("dbo.Campanies");
        }
    }
}
