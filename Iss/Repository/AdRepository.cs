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

        public List<Ad> getAdsThatAreNotInAdSet() 
        { 
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Ad WHERE AdSetID IS NULL AND AdAccountID = @adAccountId";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.getInstance().Id);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            List<Ad> ads = new List<Ad>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string description = dataRow["Description"].ToString();
                string url = dataRow["Url"].ToString();
                string photo = dataRow["Photo"].ToString();
                Ad ad = new Ad(id, name, photo, description, url);
                ads.Add(ad);
            }
            databaseConnection.CloseConnection();
            return ads;
        }

    }
}
