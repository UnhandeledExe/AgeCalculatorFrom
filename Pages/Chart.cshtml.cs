using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace AgeCalculatorFrom.Pages
{
    public class ChartModel : PageModel
    {
        private readonly ILogger<ChartModel> _logger;

        public ChartModel(ILogger<ChartModel> logger)
        {
            _logger = logger;
        }

        public int MaleAmount { get; set; }
        public int FemaleAmount { get; set; }

        public int AgesZeroToFifteen { get; set; }
        public int AgesSixteenToThirty { get; set; }
        public int AgesThirtyoneToFortyfive { get; set; }
        public int AgesFortysixAndAbove { get; set; }

        public void OnGet()
        {
            this.MaleAmount = CalculateQuery("Gender = 0");
            this.FemaleAmount = CalculateQuery("Gender = 1");
            this.AgesZeroToFifteen = CalculateQuery("Age < 16");
            this.AgesSixteenToThirty = CalculateQuery("Age BETWEEN 16 AND 30");
            this.AgesThirtyoneToFortyfive = CalculateQuery("Age BETWEEN 31 AND 45");
            this.AgesFortysixAndAbove = CalculateQuery("Age >45");
        }
        private static int CalculateQuery(String Columntoselect)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgeCalculatorFrom.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            int Sumofselected = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Person WHERE " + Columntoselect;
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Sumofselected++;
                        }
                    }
                    con.Close();
                }
            }

            return Sumofselected;
        }

    }
}