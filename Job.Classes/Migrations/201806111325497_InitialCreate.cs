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
                        BirthDate = c.DateTime(nullable: false),
                        Grade_Id = c.Int(),
                        Specializations_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.Grade_Id)
                .ForeignKey("dbo.Specialization", t => t.Specializations_Id)
                .Index(t => t.Grade_Id)
                .Index(t => t.Specializations_Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Commentary = c.String(),
                        Employee_Id = c.Int(),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employer_Id);
            
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
                        Salary = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        Number = c.String(),
                        Employer_Id = c.Int(),
                        Specialization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .ForeignKey("dbo.Specialization", t => t.Specialization_Id)
                .Index(t => t.Employer_Id)
                .Index(t => t.Specialization_Id);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "Specialization_Id", "dbo.Specialization");
            DropForeignKey("dbo.Employees", "Specializations_Id", "dbo.Specialization");
            DropForeignKey("dbo.Vacancies", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Resumes", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Resumes", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Grade_Id", "dbo.Grade");
            DropIndex("dbo.Vacancies", new[] { "Specialization_Id" });
            DropIndex("dbo.Vacancies", new[] { "Employer_Id" });
            DropIndex("dbo.Resumes", new[] { "Employer_Id" });
            DropIndex("dbo.Resumes", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "Specializations_Id" });
            DropIndex("dbo.Employees", new[] { "Grade_Id" });
            DropTable("dbo.Specialization");
            DropTable("dbo.Vacancies");
            DropTable("dbo.Employers");
            DropTable("dbo.Resumes");
            DropTable("dbo.Grade");
            DropTable("dbo.Employees");
        }
    }
}
