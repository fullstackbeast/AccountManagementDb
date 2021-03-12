using System;
using System.Collections.Generic;
using System.Text;
using BankManagementSystemDB.Domain.Service;


namespace BankManagementSystemDB
{
    public class Auth
    {

        static AccountHolderService AccountHolderService = new AccountHolderService(new AccountHolderRepository());
        static ManagerService ManagerService = new ManagerService(new ManagerRepository());

        public static bool isHolderLoggedIn = false;
        public static bool isManagerLoggedIn = false;


        public static void RegisterAccountHolder()
        {
            Console.Clear();
            Console.WriteLine("     ACCOUNT HOLDER REGISTRATION");

            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Enter your Date Of Birth (yyyy/mm/dd): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter your Email Address: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();

            Console.Write("Confirm your Password:  ");
            string confirmPassword = Console.ReadLine();


            AccountHolderService.CreateAccountHolder(firstName, lastName, middleName, dateOfBirth, email, phoneNumber, address, password, confirmPassword);
        }

        public static bool loginaccountholder()
        {


            if (isHolderLoggedIn == true)
            {
                return isHolderLoggedIn;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("    Account Holder Login");
                Console.Write("enter your email: ");
                string email = Console.ReadLine();
                
                int userId = AccountHolderService.LogInAccountholder(email);

                if (userId != 0) isHolderLoggedIn = true;

                AccountHolderService.GetAccountDetails(email);

                return isHolderLoggedIn;
            }

        }
        public static void logoutaccountholder()
        {
            isHolderLoggedIn = false;
            AccountHolderService.LogoutAccountholder();
        }

        //// REGISTER MANAGER ACCOUNT

        public static void CreateManager()
        {
            Console.Clear();
            Console.WriteLine("     account manager registration");


            Console.Write("enter your first name: ");
            string firstname = Console.ReadLine();

            Console.Write("enter your last name: ");
            string lastname = Console.ReadLine();

            Console.Write("enter your middle name: ");
            string middlename = Console.ReadLine();

            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string password = Console.ReadLine();

            Console.Write("confirm your password: ");
            string checkpassword = Console.ReadLine();

            Console.WriteLine("Manager's account created succesfully");

            ManagerService.CreateManager(firstname, lastname, middlename, email, password, checkpassword);
        }

        public static bool LoginAccountManager()
        {

            if (isManagerLoggedIn)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("     ACCOUNT MANAGER LOGIN");
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                int id = ManagerService.LogInManager(email);

                isManagerLoggedIn = (id != 0);

                return isManagerLoggedIn;


            }


         


        }
        public static void LogoutAccountManager()
        {
            isManagerLoggedIn = false;
            ManagerService.LogoutAccountManager();
        }


    }
}
