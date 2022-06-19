using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace AgeCalculatorFrom.Models
{
    public class Person
    {
        private int ageCalculate(DateTime BirthDate)
        {
            DateTime now = DateTime.Today;

            int age = now.Year - BirthDate.Year - 1;

            if (BirthDate.Month < now.Month)
            {
                age++;
            }
            else if (BirthDate.Month == now.Month && BirthDate.Day < now.Day)
            {
                age++;
            }
            return age;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public string City { get; set; }
        public int Age
        {
            get { return ageCalculate(Birthday); }
            set { }
        }
        public List<Person> GetChartData(string connectionString)
        {
            List<Person> chartDataList = new List<Person>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT Age FROM Person";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Person person = new Person();
                    person.Age = Convert.ToInt32(dr["Age"]);
                    chartDataList.Add(person);
                }
            }
            return chartDataList;
        }
    }
    public enum Genders
    {
        Erkek = 0,
        Kadın = 1
    }
}
