using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Interface.Service
{
    interface IManagerService
    {
        public List<AccountHolder> ListAccountHolders();

        public int CreateManager(string firstName, string lastName, string middleName, string email, string password, string checkPassword);

        public Manager FindByEmail(string email);

        public bool RemoveAccountHolder(int id);

        public bool UpdateAccountHolder(AccountHolder accountHolder);
    }
}
