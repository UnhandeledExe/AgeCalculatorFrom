using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgeCalculatorFrom.Data;
using AgeCalculatorFrom.Models;

namespace AgeCalculatorFrom.Pages.People
{
    public class DetailsModel : PageModel
    {
        private readonly AgeCalculatorFrom.Data.PeopleContext _context;

        public DetailsModel(AgeCalculatorFrom.Data.PeopleContext context)
        {
            _context = context;
        }

      public Person Person { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var person = await _context.People.FirstOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            else 
            {
                Person = person;
            }
            return Page();
        }
    }
}
