using System.Data.Entity;

namespace CodeFirstEF
{
    public class Context : DbContext
    {
        public Context() : base(@"Data Source = .; Initial Catalog= codeFirstDataBase ; Integrated Security=True")
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
