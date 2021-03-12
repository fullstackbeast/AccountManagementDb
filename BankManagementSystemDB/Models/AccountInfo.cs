using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Models
{
    public class AccountInfo : Details
    {
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string AccountNumber { get; set; }

        public double AccountBalance { get; set; }

        public int AccountHolderId { get; set; }

        public int Pin { get; set; }

        public int AccountStatus { get; set; }
        public AccountHolderRepository AccountHolderRepository { get; }

        public AccountInfo(int id, string firstName, string lastName, string middleName, string email, DateTime dateOfBirth, string phoneNumber, string address ,string password, string accountNumber, double accountBalance, int pin, int accountStatus) : base(id, firstName, lastName, middleName, email, password)
        {
            Address = address;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
            AccountHolderId = id;
            Pin = pin;
            AccountStatus = accountStatus;
        }

        

      
    }
}
