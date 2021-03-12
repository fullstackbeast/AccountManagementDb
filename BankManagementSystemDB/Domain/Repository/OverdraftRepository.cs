using System;
using System.Collections.Generic;
using BankManagementSystemDB.Models;
using MySql.Data.MySqlClient;

namespace BankManagementSystemDB.Domain.Repository
{
    public class OverdraftRepository
    {

        private Databasecon databasecon = new Databasecon();
        private MySqlConnection connection;

        public OverdraftRepository()
        {
            connection = databasecon.getconnection();
        }


        public bool Create(Overdraft overdraft)
        {
            connection.Open();

            try
            {

                string query = "INSERT INTO overdrafts(accountHolderId, amount, overdraftStatus, amountLeft) VALUES('" + overdraft.AccountHolderId + "', '" + overdraft.Amount + "', '" + overdraft.Status + "', '" + overdraft.AmountLeft + "')";

                MySqlCommand command = new MySqlCommand(query, connection);

                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    connection.Close();
                    return true;
                }

                else
                {
                    connection.Close();
                    return false;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connection.Close();
            }
            connection.Close();

            return false;
        }


        public List<Overdraft> FindOverdrafts(int holderId)
        {
            List<Overdraft> allOverdrafts = new List<Overdraft>();

            connection.Open();

            try
            {
                string query = $"SELECT * FROM `overdrafts` where  `overdrafts`.`accountHolderId` = '{holderId}';";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int accountHolderId = reader.GetInt32(1);
                    double overdraftAmount = reader.GetDouble(2);
                    DateTime overdraftDate = reader.GetDateTime(3);
                    int overdraftStatus = reader.GetInt32(4);
                    double amountLeft = reader.GetDouble(5);

                    Overdraft aoverdraft = new Overdraft(accountHolderId, overdraftAmount, overdraftDate, overdraftStatus, amountLeft);

                    allOverdrafts.Add(aoverdraft);

                }
                connection.Close();
                return allOverdrafts;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return allOverdrafts;
            }

        }


        public bool Update(Overdraft overdraft)
        {
            connection.Open();
            try
            {


                string query = $"Update `overdrafts` set `overdrafts`.`overdraftStatus` = '{overdraft.Status}', `overdrafts`.`amountLeft` = '{overdraft.AmountLeft}' WHERE  `overdrafts`.`accountHolderId` = '{overdraft.AccountHolderId}' and `overdrafts`.`overdraftStatus` = 1";

                MySqlCommand command = new MySqlCommand(query, connection);

                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    connection.Close();
                    return true;
                }

                else
                {
                    connection.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public List<Overdraft> ListAllOverdrafts()
        {
            List<Overdraft> allOverdrafts = new List<Overdraft>();

            connection.Open();

            try
            {
                string query = $"SELECT * FROM `overdrafts` ;";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int accountHolderId = reader.GetInt32(1);
                    double amount = reader.GetDouble(2);
                    DateTime dateOfApproval = reader.GetDateTime(3);
                    int overdraftStatus = reader.GetInt32(4);
                    double amountLeft = reader.GetDouble(5);

                    Overdraft overdraft = new Overdraft(accountHolderId, amount, dateOfApproval, overdraftStatus, amountLeft);


                    allOverdrafts.Add(overdraft);

                }
                connection.Close();
                return allOverdrafts;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return allOverdrafts;
            }
        }
       
    }
}