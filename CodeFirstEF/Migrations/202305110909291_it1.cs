namespace CodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class it1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectEmployees", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectEmployees", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.ProjectEmployees", new[] { "Project_Id" });
            DropIndex("dbo.ProjectEmployees", new[] { "Employee_Id" });
            CreateTable(
                "dbo.WorksFors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Project_Id);
            
            AddColumn("dbo.Employees", "DepartmentSupervisorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentSupervisorId");
            AddForeignKey("dbo.Employees", "DepartmentSupervisorId", "HR.Department", "Id", cascadeDelete: true);
            DropTable("dbo.ProjectEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Employee_Id });
            
            DropForeignKey("dbo.Employees", "DepartmentSupervisorId", "HR.Department");
            DropForeignKey("dbo.WorksFors", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.WorksFors", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.WorksFors", new[] { "Project_Id" });
            DropIndex("dbo.WorksFors", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "DepartmentSupervisorId" });
            DropColumn("dbo.Employees", "DepartmentSupervisorId");
            DropTable("dbo.WorksFors");
            CreateIndex("dbo.ProjectEmployees", "Employee_Id");
            CreateIndex("dbo.ProjectEmployees", "Project_Id");
            AddForeignKey("dbo.ProjectEmployees", "Employee_Id", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectEmployees", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
