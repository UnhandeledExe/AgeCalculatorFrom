using Microsoft.AspNetCore.Mvc;

namespace AgeCalculatorFrom.Models
{
    public class City
    {
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }

    }
}
