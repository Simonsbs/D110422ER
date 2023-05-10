using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using System.Data.SqlClient;

namespace MyFirstAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController {
        [HttpGet]
        public List<Manufacturer> Get() {
            List<Manufacturer> result = new List<Manufacturer>();

            using (SqlConnection conn = new SqlConnection("Server=SIMONSPC\\SQLEXPRESS02;Database=MyShoeStore;Trusted_Connection=True;")) {
                conn.Open();
                
                SqlCommand cmd = null;
                try {
                    cmd = new SqlCommand("SELECT * FROM [Manufacturers];", conn);

                    SqlDataReader reader = null;
                    try {
                        reader = cmd.ExecuteReader();
                        while (reader.Read()) {
                            result.Add(Manufacturer.Create(reader));
                        }
                    } finally {
                        if (reader != null) {
                            reader.Close();
                        }
                    }

                } finally {
                    cmd.Dispose();
                }
            }
            return result;
        }

    }
}
