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
    internal class CollaborationRepository
    {

        DatabaseConnection databaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void createCollaboration(Collaboration collaboration)
        {

            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";

            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.sqlConnection);
            // Execute the query to get the influencer ID
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());

            string query = @"INSERT INTO Collaboration (AdAccountID, InfluencerID, Status, CollaborationOverview, ContentRequirements, CompensationPackage, CollaborationFee, StarDate, EndDate) 
                                VALUES (@AdAccountID, @InfluencerID, @Status, @CollaborationOverview, @ContentRequirements, @CompensationPackage, @CollaborationFee, @StarDate, @EndDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@Status", collaboration.status);
            command.Parameters.AddWithValue("@CollaborationOverview", collaboration.collaborationOverview);
            //command.Parameters.AddWithValue("@ContentRequirements", collaboration.ContentRequirements);
            command.Parameters.AddWithValue("@CompensationPackage", collaboration.compensationPackage);
            command.Parameters.AddWithValue("@CollaborationFee", collaboration.collaborationFee);
            command.Parameters.AddWithValue("@StarDate", collaboration.startDate);
            command.Parameters.AddWithValue("@EndDate", collaboration.endDate);

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<Collaboration> GetCollaborationsForAdAccount()
        {
            List<Collaboration> collaborations = new List<Collaboration>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE AdAccountID = @AdAccountID";

            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            System.Diagnostics.Debug.WriteLine(User.User.getInstance().Id);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery

            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                    Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                    dataRow["CollaborationOverview"].ToString(), dataRow["CompensationPackage"].ToString(), 
                    dataRow["CollaborationFee"].ToString(), Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day));
            }

            databaseConnection.CloseConnection();
            return collaborations;
        }


        public List<Collaboration> getCollaborationsForInfluencer()
        {

            List<Collaboration> collaborations = new List<Collaboration>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE InfluencerID = @InfluencerID";

            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            System.Diagnostics.Debug.WriteLine(User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", 1);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery

            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {

                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                    Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                    dataRow["CollaborationOverview"].ToString(),dataRow["CompensationPackage"].ToString(),
                    dataRow["CollaborationFee"].ToString(),Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ));
            }
            databaseConnection.CloseConnection();
            return collaborations;
        }
    }
}
