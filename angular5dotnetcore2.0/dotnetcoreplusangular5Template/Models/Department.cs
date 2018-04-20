using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dotnetcoreplusangular5Template.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string DepatmentName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
