﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public DetailsModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }
        public List<Models.EmployeeTask> Tasks { get; set; }




        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.id == id);

            Employee = await _context.Employee
               .Include(a => a.Employees)
               .Where(s => s.id == Employee.id)
               .FirstOrDefaultAsync();


            return Page();
        }
    }
}
