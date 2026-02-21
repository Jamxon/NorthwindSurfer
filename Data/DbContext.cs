using System.Data;
using Microsoft.Data.SqlClient;

namespace NorthwindSurfer.Data
{
    public class DbContext
    {
        public string connectionString = "Server=localhost;Database=NorthWind;Trusted_Connection=True;TrustServerCertificate=True;";

        public IDbConnection Connection => new SqlConnection(connectionString);
    }
}
