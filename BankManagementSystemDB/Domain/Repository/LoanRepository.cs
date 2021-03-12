using System;
using System.Collections.Generic;
using BankManagementSystemDB.Models;
using MySql.Data.MySqlClient;

namespace BankManagementSystemDB.Domain.Repository
{
    public class LoanRepository
    {
        private Databasecon databasecon = new Databasecon();
        private MySqlConnection connection;

        public LoanRepository()
        {

            connection = databasecon.getconnection();
        }


        public bool Create(Loan loan)
        {
            connection.Open();

            try
            {

                string query = "INSERT INTO loans(accountholderid, amount, loanStatus, amountLeft) VALUES('" + loan.AccountHolderId + "', '" + loan.Amount + "', '" + loan.Status + "', '" + loan.Amount + "')";

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


        public bool Update(Loan loan)
        {

            connection.Open();
            try
            {

                
                string query = $"Update `loans` set `loans`.`loanStatus` = '{loan.Status}', `loans`.`amountLeft` = '{loan.AmountLeft}' WHERE  `loans`.`accountHolderId` = '{loan.AccountHolderId}' and `loans`.`loanStatus` = 1";

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

        public List<Loan> FindAllLoansById(int holderId)
        {

            List<Loan> allLoans = new List<Loan>();

            connection.Open();

            try
            {
                string query = $"SELECT * FROM `loans` where  `loans`.`accountHolderId` = '{holderId}';";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int accountHolderId = reader.GetInt32(1);
                    double loanAmount = reader.GetDouble(2);
                    DateTime loanDate = reader.GetDateTime(3);
                    int loanStatus = reader.GetInt32(4);
                    double amountLeft = reader.GetDouble(5);

                    Loan aloan = new Loan(accountHolderId, loanAmount, loanDate, loanStatus, amountLeft);


                    allLoans.Add(aloan);

                }
                connection.Close();
                return allLoans;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return allLoans;
            }




        }

        public List<Loan> ListAllLoans()
        {
            List<Loan> allLoans = new List<Loan>();

            connection.Open();

            try
            {
                string query = $"SELECT * FROM `loans` ;";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int accountHolderId = reader.GetInt32(1);
                    double loanAmount = reader.GetDouble(2);
                    DateTime loanDate = reader.GetDateTime(3);
                    int loanStatus = reader.GetInt32(4);
                    double amountLeft = reader.GetDouble(5);

                    Loan aloan = new Loan(accountHolderId, loanAmount, loanDate, loanStatus, amountLeft);


                    allLoans.Add(aloan);

                }
                connection.Close();
                return allLoans;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return allLoans;
            }

        }
    }
}