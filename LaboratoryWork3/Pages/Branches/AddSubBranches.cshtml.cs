using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Branches
{
    public class AddSubBranchesModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public AddSubBranchesModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Branch Branch { get; set; }

        public IList<Models.Branch> Branches { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Branches = await _context.Branch.ToListAsync();
            Branch = await _context.Branch.FirstOrDefaultAsync(m => m.id == id);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int empId)
        {
            var findBranch = await _context.Branch
               .Include(a => a.Branches)
               .Where(a => a.id == empId)
               .FirstOrDefaultAsync();

            findBranch.Branches.Add(Branch);

            _context.Attach(Branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.id == id);
        }
    }
}