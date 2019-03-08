using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratoryWork3.Models
{
    public class EmployeesIndexData
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Models.Task> Tasks { get; set; }
    }
}
