using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgeCalculatorFrom.Models;
using Microsoft.Data.SqlClient;

namespace AgeCalculatorFrom.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly AgeCalculatorFrom.Data.PeopleContext _context;

        public CreateModel(AgeCalculatorFrom.Data.PeopleContext context)
        {
            _context = context;
        }

        public SelectList Cities { get; set; }

        public IActionResult OnGet()
        {
            this.Cities = new SelectList(PopulateCities(), "Name");
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.People == null || Person == null)
            {
                return Page();
            }

            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            MemoryStream ms = new MemoryStream();
            Request.Form.Files[0].CopyTo(ms);
            Person.ProfileImage = ms.ToArray();

            ms.Close();
            ms.Dispose();

            _context.People.Add(Person);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
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
