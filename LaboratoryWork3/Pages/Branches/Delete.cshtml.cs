using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Branches
{
    public class DeleteModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public DeleteModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Branch Branch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Branch = await _context.Branch.FirstOrDefaultAsync(m => m.id == id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            Branch = await _context.Branch.FindAsync(id);

            if (Branch != null)
            {
                _context.Branch.Remove(Branch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
