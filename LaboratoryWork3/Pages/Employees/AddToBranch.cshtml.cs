using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Employees
{
    public class AddToBranchModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public AddToBranchModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public IList<Models.Branch> Branches { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Branches = await _context.Branch.ToListAsync();
            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int empId)
        {
            var findBranch = await _context.Branch
               .Include(a => a.Employees)
               .Where(a => a.id == empId)
               .FirstOrDefaultAsync();


            findBranch.Employees.Add(Employee);

            _context.Attach(Employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.id == id);
        }
    }
}
