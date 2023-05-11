using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEF
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public int Salary { get; set; }
        [ForeignKey(nameof(Dept))]
        public int Department_ID { get; set; }
        public virtual Department Dept { get; set; }

        [ForeignKey(nameof(Dept_supervisor))]
        public int DepartmentSupervisorId { get; set; }
        public virtual Department Dept_supervisor { get; set; }
        //  public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorksFor> WorksFor { get; set; }

    }
}
