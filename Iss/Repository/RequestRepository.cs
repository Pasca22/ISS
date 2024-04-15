using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;

namespace Iss.Repository
{
    internal class RequestRepository
    {
        public void addRequest(Request request)
        {
            // Add the request to the database
           

            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();

            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";

            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.sqlConnection);
            // Execute the query to get the influencer ID
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());

            string query = "INSERT INTO Request(AdAccountID,InfluencerID,CollaborationTitle, CollaborationOverview, ContentRequirements, CompensationPackage,InfluencerAccept,StartDate, EndDate) values (@AdAccountID,@InfluencerID,@collaborationTitle, @collaborationOverview, @contentRequirements, @compensation,@influencerAccept,@startDate, @endDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@collaborationTitle", request.collaborationTitle);
            command.Parameters.AddWithValue("@collaborationOverview", request.collaborationOverview);
            command.Parameters.AddWithValue("@contentRequirements", request.contentRequirements);
            command.Parameters.AddWithValue("@compensation", request.compensation);
            command.Parameters.AddWithValue("@influencerAccept", request.influencerAccept);
            command.Parameters.AddWithValue("@startDate", request.startDate);
            command.Parameters.AddWithValue("@endDate", request.endDate);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();

        }

        public void deleteRequest(Request request)
        {
            // Delete the request from the database
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();
            string query = "DELETE FROM Request WHERE CollaborationTitle=@collaborationTitle";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@collaborationTitle", request.collaborationTitle);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();

        }
    }
}
