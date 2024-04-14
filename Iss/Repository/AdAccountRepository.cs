using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public class AdAccountRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

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
                adAccount = new AdAccount(dataRow["ID"].ToString(),dataRow["NameOfCompany"].ToString(), dataRow["DomainOfActivity"].ToString(), dataRow["WebSiteUrl"].ToString(), dataRow["Password"].ToString(), dataRow["TaxIdentificationNumber"].ToString(), dataRow["HeadquartersLocation"].ToString(), dataRow["AuthorizingInstitution"].ToString());
            }

            databaseConnection.CloseConnection();
            return adAccount;
        }   

        public void AddAdAccount(AdAccount adAccount)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO AdAccount (NameOfCompany, DomainOfActivity, WebSiteUrl, Password, TaxIdentificationNumber, HeadquartersLocation, AuthorizingInstitution) VALUES (@nameOfCompany, @domainOfActivity, @webSiteUrl, @password, @taxIdentificationNumber, @headquartersLocation, @authorizingInstitution)";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@nameOfCompany", adAccount.nameOfCompany);
            command.Parameters.AddWithValue("@domainOfActivity", adAccount.domainOfActivity);
            command.Parameters.AddWithValue("@webSiteUrl", adAccount.siteUrl);
            command.Parameters.AddWithValue("@password", adAccount.password);
            command.Parameters.AddWithValue("@taxIdentificationNumber", adAccount.taxIdentificationNumber);
            command.Parameters.AddWithValue("@headquartersLocation", adAccount.headquartersLocation);
            command.Parameters.AddWithValue("@authorizingInstitution", adAccount.authorisingInstituion);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<Ad> GetAdsForCurrentUser()
        {
            List<Ad> ads = new List<Ad>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Ad WHERE AdAccountId = @id";
            SqlCommand command = new SqlCommand(@query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@id", User.User.getInstance().Id);
            adapter.SelectCommand = command;
            dataSet.Clear();
            adapter.Fill(dataSet, "Ad");

            foreach (DataRow row in dataSet.Tables["Ad"].Rows)
            {
                Ad ad = new Ad(row["ID"].ToString(), row["Name"].ToString(), row["Photo"].ToString(), row["Description"].ToString(), row["Url"].ToString());
                ads.Add(ad);
            }
            return ads;
        }

        public List<AdSet> getAdSetsForCurrentUser()
        {
            databaseConnection.OpenConnection();
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM AdSet WHERE AdAccountID = @adAccountId";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.getInstance().Id);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            dataSet.Clear();
            adapter.Fill(dataSet);
            List<AdSet> adSets = new List<AdSet>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            databaseConnection.CloseConnection();
            return adSets;
        }
    }
}
