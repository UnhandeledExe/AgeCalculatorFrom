using AgeCalculatorFrom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgeCalculatorFrom.Pages
{
    public class ShowDataModel : PageModel
    {
        public List<Person> chartDataList = new List<Person>();
        string connectionString;
        readonly IConfiguration _configuration;
        
        public ShowDataModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            chartDataList = PersonData();
        }

        public List<Person> PersonData()
        {
            connectionString = _configuration.GetConnectionString("ConnectionStrings.PeopleContext");
            List<Person> personsList = new List<Person>();
            Person person = new Person();
            personsList = person.GetChartData(connectionString);
            return personsList;
        }
    }
}
