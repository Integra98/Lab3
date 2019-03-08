using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratoryWork3.Models
{
    public class EmployeeTask
    {
        public int EmployeeID { get; set; }
        public int TaskID { get; set; }
        public Employee Employee { get; set; }
        public Task Task { get; set; }
    }

   
}
