using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    internal class AdRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void addAd(Ad ad)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO Ad(Name,Description,Url,AdAccountID,Photo) values (@name, @description, @url, @adAccountId,@photo)";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", ad.productName);
            command.Parameters.AddWithValue("@description", ad.description);
            command.Parameters.AddWithValue("@url", ad.websiteLink);
            command.Parameters.AddWithValue("@photo", ad.photo);
            command.Parameters.AddWithValue("@adAccountId", User.User.getInstance().Id);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();

        }

    }
}
