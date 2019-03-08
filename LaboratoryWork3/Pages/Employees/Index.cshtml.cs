using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public IndexModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }
        public List<Models.Task> Tasks { get; set; }


        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();

            Employee = await _context.Employee
              .Include(a => a.Employees)
              .ToListAsync();


        }
    }
}
