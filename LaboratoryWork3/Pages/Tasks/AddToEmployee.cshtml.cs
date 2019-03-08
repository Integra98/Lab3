using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaboratoryWork3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Tasks
{
    public class AddToEmployeeModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public AddToEmployeeModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Task Task { get; set; }

        public List<Employee> Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employees = await _context.Employee.ToListAsync();
            Task = await _context.Task.FirstOrDefaultAsync(m => m.id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int empId)
        {

            var findEmployee = await _context.Employee
               .Where(a => a.id == empId)
               .FirstOrDefaultAsync();

            _context.EmployeeTask.Add(new EmployeeTask { Employee = findEmployee, Task = Task });

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.id == id);
        }
    }
}