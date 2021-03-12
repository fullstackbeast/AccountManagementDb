using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public class Loan : LoanOverdraftDetails<Loan>
    {

        public string TypeOfLoan { get; set; }

        public double AmountLeft { get; set; }
        public DateTime LoanDate { get; }

        public Loan(int accountHolderId, double amount, int status = 1) : base(accountHolderId, amount, status)
        {


        }
        public Loan(int accountHolderId, double amount, DateTime loanDate,  int status,  double amountLeft) : base(accountHolderId, amount, status)
        {
            LoanDate = loanDate;
            AmountLeft = amountLeft;
        }


    }







}

