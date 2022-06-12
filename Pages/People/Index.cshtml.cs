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
    public class IndexModel : PageModel
    {
        private readonly AgeCalculatorFrom.Data.PeopleContext _context;

        public IndexModel(AgeCalculatorFrom.Data.PeopleContext context)
        {
            _context = context;
        }

        public string FnameSort { get; set; }
        public string LnameSort { get; set; }
        public string CitySort { get; set; }
        public string AgeSort { get; set; }
        public string CurrentFilter { get; set; }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            FnameSort = sortOrder == "FirstName" ? "fname_desc" : "FirstName";
            LnameSort = sortOrder == "LastName" ? "lname_desc" : "LastName";
            CitySort = sortOrder == "City" ? "city_desc" : "City";
            AgeSort = sortOrder == "Age" ? "age_desc" : "Age";

            CurrentFilter = searchString;
            
            IQueryable<Person> peopleIQ = from p in _context.People select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                peopleIQ = peopleIQ.Where(p => p.FirstName.Contains(searchString)
                                        || p.LastName.Contains(searchString)
                                        || p.City.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "fname_desc":
                    peopleIQ = peopleIQ.OrderByDescending(p => p.FirstName);
                    break;
                case "FirstName":
                    peopleIQ = peopleIQ.OrderBy(p => p.FirstName);
                    break;
                case "lname_desc":
                    peopleIQ = peopleIQ.OrderByDescending(p => p.LastName);
                    break;
                case "LastName":
                    peopleIQ = peopleIQ.OrderBy(p => p.LastName);
                    break;
                case "city_desc":
                    peopleIQ = peopleIQ.OrderByDescending(p => p.City);
                    break;
                case "City":
                    peopleIQ = peopleIQ.OrderBy(p => p.City);
                    break;
                case "age_desc":
                    peopleIQ = peopleIQ.OrderByDescending(p => p.Age);
                    break;
                case "Age":
                    peopleIQ = peopleIQ.OrderBy(p => p.Age);
                    break;
            }

            Person = await peopleIQ.AsNoTracking().ToListAsync();

            /*if (_context.People != null)
            {
                Person = await _context.People.ToListAsync();
            }*/
        }
    }
}
