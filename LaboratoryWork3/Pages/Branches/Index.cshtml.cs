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
    public class IndexModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public IndexModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        public IList<Branch> Branch { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Branch = await _context.Branch.ToListAsync();

            Branch = await _context.Branch
              .Include(a => a.Branches)
              .ToListAsync();

            Branch = await _context.Branch
              .Include(a => a.Employees)
              .ToListAsync();
        }
    }
}
