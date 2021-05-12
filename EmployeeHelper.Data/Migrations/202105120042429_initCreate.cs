namespace EmployeeHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BufferReplacement",
                c => new
                    {
                        BufferId = c.Int(nullable: false, identity: true),
                        IsComplete = c.Boolean(nullable: false),
                        DueOnDate = c.DateTime(nullable: false),
                        CompletedOnDate = c.DateTime(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.BufferId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeGuid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Shifts = c.Int(nullable: false),
                        HiringDate = c.DateTime(nullable: false),
                        ShiftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.ShiftTable", t => t.ShiftId, cascadeDelete: true)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.BulkTechSamples",
                c => new
                    {
                        BTId = c.Int(nullable: false, identity: true),
                        IsComplete = c.Boolean(nullable: false),
                        DueOnDate = c.DateTime(nullable: false),
                        CompletedOnDate = c.DateTime(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.BTId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OverTime",
                c => new
                    {
                        OTId = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        OTDay = c.DateTime(nullable: false),
                        HoursWorked = c.Decimal(precision: 18, scale: 2),
                        Days = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.OTId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.TamcTymcSamples",
                c => new
                    {
                        TId = c.Int(nullable: false, identity: true),
                        IsComplete = c.Boolean(nullable: false),
                        DueOnDate = c.DateTime(nullable: false),
                        CompletedOnDate = c.DateTime(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.TId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ShiftTable",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        Shift = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.BufferReplacement", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "ShiftId", "dbo.ShiftTable");
            DropForeignKey("dbo.TamcTymcSamples", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.OverTime", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.BulkTechSamples", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TamcTymcSamples", new[] { "EmployeeId" });
            DropIndex("dbo.OverTime", new[] { "EmployeeId" });
            DropIndex("dbo.BulkTechSamples", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "ShiftId" });
            DropIndex("dbo.BufferReplacement", new[] { "EmployeeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ShiftTable");
            DropTable("dbo.TamcTymcSamples");
            DropTable("dbo.OverTime");
            DropTable("dbo.BulkTechSamples");
            DropTable("dbo.Employee");
            DropTable("dbo.BufferReplacement");
        }
    }
}
