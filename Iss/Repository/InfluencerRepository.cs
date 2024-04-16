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
    public class InfluencerRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public List<Influencer> GetInfluencers()
        {
            List<Influencer> influencers = new List<Influencer>();
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM Influencer";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            databaseConnection.OpenConnection();
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);
            
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string id = row["ID"].ToString();
                string name = row["Name"].ToString();
                int followers = Convert.ToInt32(row["FollowerCount"]);
                int price = Convert.ToInt32(row["CollaborationPrice"]);
                Influencer influencer = new Influencer(id, name, followers, price);
                influencers.Add(influencer);
            }
            return influencers;
        }
    }
}
