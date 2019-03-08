using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratoryWork3.Models
{
    public class Branch
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<Branch> Branches { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
