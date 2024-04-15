using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public class CampaignRepository
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void addCampaign(Campaign campaign)
        {
            DatabaseConnection.OpenConnection();
            string query = "INSERT INTO Campaign(Name, StartDate, Duration, AdAccountID) values (@campaignName, @startDate, @duration, @adAccountID)";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaign.campaignName);
            command.Parameters.AddWithValue("@startDate", campaign.startDate);
            command.Parameters.AddWithValue("@duration", campaign.duration);
            command.Parameters.AddWithValue("@adAccountID", User.User.getInstance().Id);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public Campaign getCampaignByName(Campaign campaign)
        {
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM Campaign WHERE Name = @campaignName";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaign.campaignName);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                campaign.id = id;
            }

            DatabaseConnection.CloseConnection();
            return campaign;
        }

        public void addAdSetToCampaign(Campaign campaign, AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = @campaignID WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaign.id);
            command.Parameters.AddWithValue("@adSetID", adSet.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
