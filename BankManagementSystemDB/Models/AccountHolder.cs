using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public class AccountHolder : Details
    {
        
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public AccountHolder(int id, string firstName, string lastName, string middleName, string email, string password, DateTime dateOfBirth, string phoneNumber, string address) : base(id, firstName, lastName, middleName, email, password)
        {
            DateOfBirth = dateOfBirth;

            PhoneNumber = phoneNumber;

            Address = address;
           
        }
    }
}
