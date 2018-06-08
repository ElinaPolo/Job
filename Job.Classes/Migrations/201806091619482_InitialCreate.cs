namespace Job.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Education = c.String(),
                        Grade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.Grade_Id)
                .Index(t => t.Grade_Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfTheCompany = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VacancyName = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Schedule = c.String(),
                        Address = c.String(),
                        ContactMan = c.String(),
                        Number = c.String(),
                        Employer_Id = c.Int(),
                        Specialization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .ForeignKey("dbo.Specialization", t => t.Specialization_Id)
                .Index(t => t.Employer_Id)
                .Index(t => t.Specialization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "Specialization_Id", "dbo.Specialization");
            DropForeignKey("dbo.Vacancies", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Specialization", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Grade_Id", "dbo.Grade");
            DropIndex("dbo.Vacancies", new[] { "Specialization_Id" });
            DropIndex("dbo.Vacancies", new[] { "Employer_Id" });
            DropIndex("dbo.Specialization", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "Grade_Id" });
            DropTable("dbo.Vacancies");
            DropTable("dbo.Employers");
            DropTable("dbo.Specialization");
            DropTable("dbo.Grade");
            DropTable("dbo.Employees");
        }
    }
}
