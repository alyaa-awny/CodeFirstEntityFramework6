using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEF
{
    [Table("Department", Schema = "HR")]
    public class Department
    {

        public int Id { get; set; }

        [Column("DeptName")]
        public string Name { get; set; }
        [InverseProperty("Dept")]
        public virtual ICollection<Employee> Employees { get; set; }

        [InverseProperty("Dept_supervisor")]
        public virtual ICollection<Employee> Supervisors { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}