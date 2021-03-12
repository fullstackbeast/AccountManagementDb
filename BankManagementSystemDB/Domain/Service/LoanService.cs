using System;
using System.Collections.Generic;
using BankManagementSystemDB.Domain.Repository;

namespace BankManagementSystemDB.Domain.Service
{
    public class LoanService
    {
        private LoanRepository LoanRepository;
        public LoanService(LoanRepository loanRepository)
        {
            LoanRepository = loanRepository;
        }


        public void GetLoan(int accountHolderId, double amount, string type)
        {

            Loan newLoan = new Loan(accountHolderId, amount);

            try
            {

                List<Loan> allLoan = LoanRepository.FindAllLoansById(accountHolderId);

                if (allLoan.Count < 1)
                {

                    LoanRepository.Create(newLoan);
                }
                else
                {
                    Loan activeLoan = FindActiveLoan(allLoan);
                    if (activeLoan == null)
                    {
                        LoanRepository.Create(newLoan);
                    }

                    else
                    {
                        throw new Exception($"You currently have an unpaid loan of {activeLoan.AmountLeft}. Please pay up to qualify for another");
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public Loan FindActiveLoan(List<Loan> allLoan)
        {
            return allLoan.Find(x => x.Status == 1);
        }

        public void PayLoan(int accountHolderId, double amount)
        {

            Console.WriteLine(accountHolderId);
            Console.WriteLine(amount);

            List<Loan> allLoan = LoanRepository.FindAllLoansById(accountHolderId);

            if (allLoan.Count < 1 || (FindActiveLoan(allLoan) == null))
            {
                Console.WriteLine("You do not have any active loan ):");
            }
            else
            {

                Loan activeLoan = FindActiveLoan(allLoan);

                activeLoan.AmountLeft -= amount;

                if (activeLoan.AmountLeft <= 0) activeLoan.AmountLeft = 0;

                if (activeLoan.AmountLeft == 0) activeLoan.Status = 0;

                if (LoanRepository.Update(activeLoan))
                {
                    string message = (activeLoan.Status == 0) ? $"Congratulations: Your Loan has been completely paid." : $"You have successfully paid {amount}. You currently have {activeLoan.AmountLeft} left to pay";

                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("An eeror occoured");
                }
            }

        }

        public double checkLoanBalance(int accountHolderId)
        {
            double balance = 0;

            List<Loan> allLoan = LoanRepository.FindAllLoansById(accountHolderId);

            if(allLoan.Count >= 1){
                Loan activeLoan = FindActiveLoan(allLoan);
                if(activeLoan != null){
                    balance = activeLoan.AmountLeft;
                }
            }

            return balance;
        }

        public List<Loan> GetAllLoans()
        {

            return LoanRepository.ListAllLoans();
        }
    }
}