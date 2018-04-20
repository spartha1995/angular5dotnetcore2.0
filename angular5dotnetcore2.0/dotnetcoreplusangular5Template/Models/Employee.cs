using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dotnetcoreplusangular5Template.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
