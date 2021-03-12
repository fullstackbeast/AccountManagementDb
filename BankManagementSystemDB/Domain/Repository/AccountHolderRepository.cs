using BankManagementSystemDB.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManagementSystemDB
{
    public class AccountHolderRepository : IAccountHolderRepository
    {
        public static AccountHolder LoggedInAccount;
        private Databasecon databasecon = new Databasecon();
        private MySqlConnection _connection;

        public static AccountHolder loggedinAccountHolder;
        public static Account loggedinAccount;

        public AccountHolderRepository()
        {
            _connection = databasecon.getconnection();
        }


        public List<AccountHolder> ListAccountHolders()
        {
            List<AccountHolder> accountHolders = new List<AccountHolder>();
            try
            {

                _connection.Open();

                string query = "SELECT * FROM accountholders";

                MySqlCommand command = new MySqlCommand(query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    {
                        // int id = reader.GetInt32(0);
                        // string firstName = reader.GetString(1);
                        // string lastName = reader.GetString(2);
                        // string middleName = reader.GetString(3);
                        // DateTime dateOfBirth = reader.GetDateTime(4);
                        // string phoneNumber = reader.GetString(6);
                        // string address = reader.GetString(7);
                        // string password = reader.GetString(6);

                        // AccountHolder accountHolder = new AccountHolder(id, firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address);
                    }

                    Console.WriteLine($"{reader[0]} -- {reader[1]}");
                }

                reader.Close();
                _connection.Close();
            }
            catch (Exception ea)
            {
                throw new Exception(ea.Message);
            }

            return accountHolders;
        }

        public int CreateAccountHolder(string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password)
        {
            try
            {

                _connection.Open();

                string query = "INSERT INTO accountholders(firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address) VALUES('" + firstName + "', '" + lastName + "','" + middleName + "', '" + email + "', '" + password + "', '" + dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + phoneNumber + "', '" + address + "')";

                MySqlCommand command = new MySqlCommand(query, _connection);

                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    _connection.Close();

                    AccountHolder accountHolder = FindByEmail(email);

                    return accountHolder.Id;
                }
            }
            catch (Exception ea)
            {
                Console.WriteLine($"err2: {ea.Message}");
            }

            _connection.Close();

            return 0;

        }

        public AccountHolder FindByEmail(string email)
        {

            _connection.Open();
            AccountHolder accountHolder = null;
            try
            {

                string query = "SELECT * FROM accountholders WHERE email = '" + email + "'";

                MySqlCommand command = new MySqlCommand(query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string middleName = reader.GetString(3);
                    string phoneNumber = reader.GetString(6);
                    DateTime dateOfBirth = reader.GetDateTime(4);
                    string demail = reader.GetString(5);
                    string address = reader.GetString(7);
                    string password = reader.GetString(8);

                    accountHolder = new AccountHolder(id, firstName, lastName, middleName, demail, password, dateOfBirth, phoneNumber, address);

                    _connection.Close();

                    return accountHolder;
                }
                _connection.Close();

                return accountHolder;
            }
            catch (MySqlException ea)
            {
                Console.WriteLine($"read error: {ea.Message}");
                _connection.Close();
                return accountHolder;

            }

            finally
            {
                _connection.Close();
            }

        }

        public AccountInfo AccountInfos(string demail)
        {

            AccountInfo accountInfo = null;

            try
            {

                _connection.Open();

                string query = $"Select * from `accountholders` left outer join `accounts` on `accountholders`.`id` = `accounts`.`accountHolderId` WHERE `accountholders`.`email` = '{demail}'";

                MySqlCommand command = new MySqlCommand(query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    Console.WriteLine(reader[i]);
                    //}

                    int accountHolderId = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string middleName = reader.GetString(3);
                    DateTime dateOfbirth = reader.GetDateTime(4);
                    string email = reader.GetString(5);
                    string phoneNumber = reader.GetString(6);
                    string address = reader.GetString(7);
                    string password = reader.GetString(8);
                    string accountNumber = reader.GetString(12);
                    double accountbalance = reader.GetDouble(13);
                    int accountPin = reader.GetInt32(14);
                    int accountStatus = reader.GetInt32(15);

                    //loggedInDetails.Add(new AccountHolder(accountHolderId, firstName, lastName, middleName, email, password, dateOfbirth, phoneNumber, address));
                    //loggedInDetails.Add(new Account(accountHolderId, accountNumber, accountbalance, accountPin, accountStatus));

                    

                    _connection.Close();

                    accountInfo = new AccountInfo(accountHolderId, firstName, lastName, middleName, email,dateOfbirth, phoneNumber, address,password, accountNumber, accountbalance, accountPin, accountStatus);

                }

                _connection.Close();
                return accountInfo; ;

            }
            catch (Exception e)
            {
                _connection.Close();
                Console.WriteLine(e.Message);
                return accountInfo;

            }
        }

        public List<AccountInfo> GetAllAccountHolders()
        {
            List<AccountInfo> allAccounts = new List<AccountInfo>();

            try
            {

                _connection.Open();

                string query = $"Select * from `accountholders` left outer join `accounts` on `accountholders`.`id` = `accounts`.`accountHolderId`";

                MySqlCommand command = new MySqlCommand(query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    

                    int accountHolderId = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string middleName = reader.GetString(3);
                    DateTime dateOfbirth = reader.GetDateTime(4);
                    string email = reader.GetString(5);
                    string phoneNumber = reader.GetString(6);
                    string address = reader.GetString(7);
                    string password = reader.GetString(8);
                    string accountNumber = reader.GetString(12);
                    double accountbalance = reader.GetDouble(13);
                    int accountPin = reader.GetInt32(14);
                    int accountStatus = reader.GetInt32(15);

                  AccountInfo  accountInfo = new AccountInfo(accountHolderId, firstName, lastName, middleName, email, dateOfbirth, phoneNumber, address, password, accountNumber, accountbalance, accountPin, accountStatus);


                    allAccounts.Add(accountInfo);

                }
                _connection.Close();
                return allAccounts;

            }
            catch (Exception e)
            {
                _connection.Close();
                Console.WriteLine(e.Message);
                return allAccounts;

            }

        }

        public bool RemoveAccountHolder(int id)
        {
            try
            {
                _connection.Open();
                var sql = "delete from accountholders where id='" + id + "'";
                MySqlCommand command = new MySqlCommand(sql, _connection);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    _connection.Close();
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return false;

        }

        public bool UpdateAccountHolder(AccountHolder accountHolder)
        {
            try
            {
                _connection.Open();
                var sql = "update accountHolders set firstName ='" + accountHolder.FirstName + "',lastName='" + accountHolder.LastName + "',middleName='" + accountHolder.MiddleName + "',phoneNumber='" + accountHolder.PhoneNumber + "',address='" + accountHolder.Address + "',password='" + accountHolder.Password + "' where id='" + accountHolder.Id + "'";
                MySqlCommand command = new MySqlCommand(sql, _connection);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    _connection.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close();
            return false;
        }

        public void DisplayAll()
        {
            //List<AccountHolder> accountHolders = getAl();
            //foreach (AccountHolder accountHolder in accountHolders)
            //{
            //    Console.WriteLine($"{accountHolder.getId()}, {accountHolder.getFirstName()}, {accountHolder.getLastName()}, {accountHolder.getMiddleName(),{accountHolder.getEmail()},{accountHolder.getPassword()}, {accountHolder.getDateOfBirth()}, {accountHolder.getPhoneNumber()},{accountHolder.getAddresss()}");
            //}
        }

        public AccountHolder FindById(int id)
        {
            AccountHolder accountHolder = null;
            try
            {
                _connection.Open();

                var sql = "SELECT * FROM accountholders WHERE id = '" + id + "'";

                MySqlCommand command = new MySqlCommand(sql, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string middleName = reader.GetString(3);
                    string email = reader.GetString(4);
                    string password = reader.GetString(5);
                    DateTime dateOfBirth = reader.GetDateTime(6);
                    string phoneNumber = reader.GetString(7);
                    string address = reader.GetString(8);
                    accountHolder = new AccountHolder(id, firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address);

                }
                Console.WriteLine(reader[0] + " -- " + reader[1]);

            }

            catch (MySqlException ea)
            {
                Console.WriteLine(ea.Message);
            }
            _connection.Close();
            return accountHolder;
        }

        public AccountInfo GetAccountInfo(string demail)
        {
            AccountInfo accountInfo = null;

            try
            {

                _connection.Open();

                string query = $"Select * from `accountholders` left outer join `accounts` on `accountholders`.`id` = `accounts`.`accountHolderId` WHERE `accountholders`.`email` = '{demail}'";

                MySqlCommand command = new MySqlCommand(query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    Console.WriteLine(reader[i]);
                    //}

                    int accountHolderId = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string middleName = reader.GetString(3);
                    DateTime dateOfbirth = reader.GetDateTime(4);
                    string email = reader.GetString(5);
                    string phoneNumber = reader.GetString(6);
                    string address = reader.GetString(7);
                    string password = reader.GetString(8);
                    string accountNumber = reader.GetString(12);
                    double accountbalance = reader.GetDouble(13);
                    int accountPin = reader.GetInt32(14);
                    int accountStatus = reader.GetInt32(15);

                    //loggedInDetails.Add(new AccountHolder(accountHolderId, firstName, lastName, middleName, email, password, dateOfbirth, phoneNumber, address));
                    //loggedInDetails.Add(new Account(accountHolderId, accountNumber, accountbalance, accountPin, accountStatus));



                    _connection.Close();

                    accountInfo = new AccountInfo(accountHolderId, firstName, lastName, middleName, email,dateOfbirth,phoneNumber,address,password, accountNumber, accountbalance, accountPin, accountStatus);

                }

                _connection.Close();
                return accountInfo; ;

            }
            catch (Exception e)
            {
                _connection.Close();
                Console.WriteLine(e.Message);
                return accountInfo;

            }
        }
    }
}