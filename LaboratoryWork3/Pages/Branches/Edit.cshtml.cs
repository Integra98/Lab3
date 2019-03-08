using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Branches
{
    public class EditModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public EditModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(Branch.id))
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

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.id == id);
        }
    }
}
