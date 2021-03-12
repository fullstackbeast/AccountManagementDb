using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public interface IManager
    {
        
        bool CreateManager(string firstName, string lastName, string middleName, string email, string password, string confirmPassword);
         public Manager FindByIdOrEmail(int id, string email);
        public Manager FindById(int id);
        public Manager FindByEmail(string email);
        //public static int LoginAccountManager(string userEmail);
        //void LogOutAccountManger();

    }
}