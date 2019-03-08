using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public IndexModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        public IList<Models.Task> Task { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Task = await _context.Task.ToListAsync();
        }
    }
}
