using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Employees
{
    public class AddSubEmployeesModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public AddSubEmployeesModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public IList<Models.Employee> Employees { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employees = await _context.Employee.ToListAsync();
            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.id == id);
            
  
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int empId)
        {
            var findEmployee = await _context.Employee
               .Include(a => a.Employees)
               .Where(a => a.id == empId)
               .FirstOrDefaultAsync();

            findEmployee.Employees.Add(Employee);

            _context.Attach(Employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.id == id);
        }
    }
}