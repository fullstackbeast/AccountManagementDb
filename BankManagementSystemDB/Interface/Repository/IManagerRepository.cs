using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Interface.Repository
{
    interface IManagerRepository
    {
       

        public bool CreateManager(string firstName, string lastName, string middleName, string email, string password);

        public Manager FindByEmail(string email);

        

        
    }
}
