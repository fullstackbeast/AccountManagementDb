using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public class Overdraft : LoanOverdraftDetails<Overdraft>
    {

        public double AmountLeft { get; set; }
        public DateTime OverdraftDate { get; }


        public Overdraft(int accountHolderId, double amount, DateTime overdraftDate,  int status, double amountLeft) : base(accountHolderId, amount, status)
        {

            AmountLeft = amountLeft;
            OverdraftDate = overdraftDate;
        }
        public Overdraft(int accountHolderId, double amount, double amountLeft, int status = 1) : base(accountHolderId, amount, status)
        {
            AmountLeft = amountLeft;
        }
    }
}
