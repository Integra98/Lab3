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
    public class DetailsModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public DetailsModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        public Branch Branch { get; set; }
        public List<Employee> Employees { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Branch = await _context.Branch.FirstOrDefaultAsync(m => m.id == id);
            Branch = await _context.Branch
              .Include(a => a.Branches)
              .Where(s => s.id == Branch.id)
              .FirstOrDefaultAsync();

            return Page();
        }
    }
}
