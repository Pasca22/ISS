using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public class AdAccountRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public AdAccount GetAdAccount(string nameOfCompany, string password)
        {
            AdAccount adAccount = null;
            databaseConnection.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();

            string query = "SELECT * FROM AdAccount WHERE NameOfCompany = @nameOfCompany AND Password = @password";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@nameOfCompany", nameOfCompany);
            command.Parameters.AddWithValue("@password", password);
            
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                adAccount = new AdAccount(dataRow["NameOfCompany"].ToString(), dataRow["DomainOfActivity"].ToString(), dataRow["WebSiteUrl"].ToString(), dataRow["Password"].ToString(), dataRow["TaxIdentificationNumber"].ToString(), dataRow["HeadquartersLocation"].ToString(), dataRow["AuthorizingInstitution"].ToString());
            }

            databaseConnection.CloseConnection();
            return adAccount;
        }   
    }
}
