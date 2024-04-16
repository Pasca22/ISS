using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Iss.Repository
{
    public class DatabaseConnection
    {
        public static string ConnectionString = "Data Source = DESKTOP-R01UH5Q\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;";

        public SqlConnection sqlConnection = new SqlConnection(ConnectionString);

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
