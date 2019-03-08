using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaboratoryWork3.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWork3.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly LaboratoryWork3.Models.LaboratoryWork3Context _context;

        public CreateModel(LaboratoryWork3.Models.LaboratoryWork3Context context)
        {
            _context = context;
        }


        [BindProperty]
        public Employee Employee { get; set; }
        public List<Employee> listOfEmployees = new List<Employee> { };
        public Models.Task newTask = new Models.Task { name= "Listen the first lesson" };

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Employee.Add(Employee);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        

    }
}