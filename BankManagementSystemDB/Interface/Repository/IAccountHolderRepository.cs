using BankManagementSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public interface IAccountHolderRepository
    {
        public  int CreateAccountHolder(string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password);
        public AccountHolder FindByEmail(string email);

        public bool UpdateAccountHolder(AccountHolder accountHolder);

        public bool RemoveAccountHolder(int id);

        public List<AccountHolder> ListAccountHolders();

        public void DisplayAll();

        //public AccountHolder FindByIdOrEmail(int id, string email);

        public AccountHolder FindById(int id);

        public AccountInfo GetAccountInfo(string email);

    }
}
