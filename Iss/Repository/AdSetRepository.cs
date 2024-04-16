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
    public class AdSetRepository
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void addAdSet(AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "INSERT INTO AdSet(Name, TargetAudience, AdAccountID) values (@name, @targetAudience, @AdAccountID)";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSet.name);
            command.Parameters.AddWithValue("@targetAudience", adSet.targetAudience);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void deleteAdSet(AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "DELETE FROM AdSet WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@id", adSet.id);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void updateAdSet(AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET Name=@Name, TargetAudience=@audience";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSet.name);
            command.Parameters.AddWithValue("@audience", adSet.targetAudience);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();

        }

        public AdSet getAdSetByName(AdSet adSet)
        {
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSet.name);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                adSet.id = id;
            }

            DatabaseConnection.CloseConnection();
            return adSet;
        }

        public void addAdToAdSet(AdSet adSet, Ad ad)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = @adSetID WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.id);
            command.Parameters.AddWithValue("@adID", ad.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void removeAdFromAdSet(AdSet adSet, Ad ad)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = NULL WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.id);
            command.Parameters.AddWithValue("@adID", ad.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public List<AdSet> getAdSetsThatAreNotInCampaign()
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID IS NULL";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            DatabaseConnection.CloseConnection();
            return adSets;
        }

        public List<AdSet> getAdSetsInCampaign(string Id)
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID=@id";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@id", Id);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            DatabaseConnection.CloseConnection();
            return adSets;
        }
    }
}
