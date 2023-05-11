namespace CodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            MoveTable(name: "dbo.Department", newSchema: "HR");
            RenameColumn(table: "HR.Department", name: "Name", newName: "DeptName");
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("HR.Department", t => t.Departments_Id)
                .Index(t => t.Departments_Id);
            
            AddColumn("dbo.Employees", "Department_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Department_ID");
            AddForeignKey("dbo.Employees", "Department_ID", "HR.Department", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Departments_Id", "HR.Department");
            DropForeignKey("dbo.Employees", "Department_ID", "HR.Department");
            DropIndex("dbo.Projects", new[] { "Departments_Id" });
            DropIndex("dbo.Employees", new[] { "Department_ID" });
            DropColumn("dbo.Employees", "Department_ID");
            DropTable("dbo.Projects");
            RenameColumn(table: "HR.Department", name: "DeptName", newName: "Name");
            MoveTable(name: "HR.Department", newSchema: "dbo");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
