using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public interface ILoan
    {
        void AddLoans();

        Loan FindLoanByAccountHolderId(int id);

        Loan FindActiveLoan(List<Loan> multipleLoan);

        Loan FindActiveLoan(int accountHolderId);

        int CountLoan(List<Loan> multipleLoan);

        bool CheckLoanBalance(int accountHolderId, bool printStatus = true);

        void PayBackLoan(int accountHolderId, double amountToPay);

        public List<Loan> ListLoans();

        List<Loan> FindMultipleLoanByAccountHolderId(int id);






    }
}
