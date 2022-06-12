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
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public string City { get; set; }
        public int Age
        {
            get { return ageCalculate(Birthday); }
            set { }
        }
    }
    public enum Genders
    {
        Erkek = 0,
        Kadın = 1
    }
}
