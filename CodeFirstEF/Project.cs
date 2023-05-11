using System.Collections.Generic;

namespace CodeFirstEF
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department Departments { get; set; }
        //public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<WorksFor> WorksFor { get; set; }
    }
}
