using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystemDB
{
    public abstract class LoanOverdraftDetails <T> : BaseEntity
    {
     

      public int AccountHolderId { get; set; }

        public double Amount { get; set; }

        public int Status { get; set; }


        public LoanOverdraftDetails(int accountHolderId, double amount ,int status = 1)
        {
            AccountHolderId = accountHolderId;
            Amount = amount;
            Status = status;           
        }

        // public T findActiveByAccountHolderId(List){

            

        //     return 
        // }
    }
}
