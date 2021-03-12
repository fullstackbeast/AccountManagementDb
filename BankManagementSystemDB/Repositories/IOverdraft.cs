using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public interface IOverdraft
    {
        void ListOverdrafts();

        void FindOverdraftByAccountHolderId(int id);

        //List<OverDraft> FindMultipleOverdraftByAccountHolderId(int id);

        //void FindActiveOverdraft(List<OverDraft> multipleOverdraft);

        bool checkOverdraftBalance(int accountHolderId, bool printStatus = true);

        void GetOverdraft(AccountHolder account, double amount);

        void PayOverdraft(AccountHolder account, double amount);
    }
}
