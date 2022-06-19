using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgeCalculatorFrom.Data;
using AgeCalculatorFrom.Models;
using Microsoft.Data.SqlClient;

namespace AgeCalculatorFrom.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly AgeCalculatorFrom.Data.PeopleContext _context;

        public EditModel(AgeCalculatorFrom.Data.PeopleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        public SelectList Cities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var person =  await _context.People.FirstOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            Person = person;
            this.Cities = new SelectList(PopulateCities(), "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.ID))
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

        private bool PersonExists(int id)
        {
          return (_context.People?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private static List<String> PopulateCities()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgeCalculatorFrom.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<String> cities = new List<String>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Name FROM City";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            cities.Add(sdr.GetString(0));
                        }
                    }
                    con.Close();
                }
            }

            return cities;
        }
    }
}
