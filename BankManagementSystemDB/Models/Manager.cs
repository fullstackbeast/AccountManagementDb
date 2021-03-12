using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public class Manager: Details
    {
        public Manager(int id, string firstName, string lastName, string middleName, string email, string password) : base(id,firstName, lastName, middleName, email, password)
        {
        }
    }
}
