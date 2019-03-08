using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaboratoryWork3.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Branches
{
    public class CreateModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public CreateModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Branch Branch { get; set; }

        public List<Employee> Employees { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Employees = await _context.Employee.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Branch.Add(Branch);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}