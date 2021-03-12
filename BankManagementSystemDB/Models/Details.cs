﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public abstract class Details : BaseEntity
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Details(int id  ,string firstName, string lastName, string middleName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Email = email;
            Password = password;
        }


    }
}
