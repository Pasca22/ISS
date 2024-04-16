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

        public void deleteAdSetFromCampaign(Campaign campaign, AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = NULL WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaign.id);
            command.Parameters.AddWithValue("@adSetID", adSet.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void deleteCampaign(Campaign campaign)
        {
            DatabaseConnection.OpenConnection();
            string query = "DELETE FROM Campaign WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@id", campaign.id);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void updateCampaign(Campaign campaign)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Campaign SET Name=@name, StartDate=@date, Duration=@duration WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@id", campaign.id);
            command.Parameters.AddWithValue("@name", campaign.campaignName);
            command.Parameters.AddWithValue("@date", campaign.startDate);
            command.Parameters.AddWithValue("@duration", campaign.duration);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
