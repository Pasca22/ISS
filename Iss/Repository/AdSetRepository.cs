﻿using Iss.Entity;
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
        DataSet dataSet = new DataSet();

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

        public AdSet getAdSetByName(AdSet adSet)
        {
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
    }
}
