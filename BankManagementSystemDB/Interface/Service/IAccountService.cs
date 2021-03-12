using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Interface.Service
{
    interface IAccountService
    {

        bool Create(int accountHolderId, double accountBalance = 0.00, int accountPin = 0, int accountStatus = 1);

        void Remove();

        Account FindByAccountNumber(string accountNumber);

        void Transfer(string accountNumber, double amountToTransfer);

        void WithdrawMoney(double amountToWithdraw);

        double CheckBalance();

        void SetPin(int pin);

        void ChangePin(int pin);

        public List<Account> ListAccounts();
    }
}
