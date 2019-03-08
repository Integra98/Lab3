using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public EditModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public List<Employee> Employees = new List<Employee> { };
        public List<Models.Task> Tasks = new List<Models.Task> { };


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employees = await _context.Employee.ToListAsync();
            Tasks = await _context.Task.ToListAsync();
            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.id == id);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public async System.Threading.Tasks.Task OnPostPushEmployeeAsync(int empId)
        {
            var findEmployee = await _context.Employee
                .Include(a => a.Employees)
                .Where(a => a.id == empId)
                .FirstOrDefaultAsync();

            findEmployee.Employees.Add(Employee);

            //st<Employee> newEmployees = new List<Employee> { };
            //wEmployees.Add(findEmployee);
            //ployee.Employees = newEmployees;
           //ystem.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!" + Employee.Employees.Count);
            //List<Employee> newEmployees = new List<Employee> { };
            //findEmployee.Employees = newEmployees;
            //ndEmployee.Employees.Add(Employee);
            //stem.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!" + findEmployee.Employees.Count);
             
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.id == id);
        }
    }
}
