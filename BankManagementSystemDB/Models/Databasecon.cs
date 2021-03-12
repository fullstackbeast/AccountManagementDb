using MySql.Data.MySqlClient;


namespace BankManagementSystemDB.Models
{
    public class Databasecon
    {

        private string connectionString = "server=localhost;user=root;database=bms;port=3306;password=html12345";
        static MySqlConnection connection;

        public MySqlConnection getconnection(){
            connection = new MySqlConnection(connectionString);
            return connection;
        }
        
    }
}