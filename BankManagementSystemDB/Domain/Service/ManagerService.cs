using BankManagementSystemDB.Domain.Repository;
using BankManagementSystemDB.Interface.Service;
using BankManagementSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Domain.Service
{
    class ManagerService : IManagerService
    {
        private readonly AccountHolderRepository _accountHolderRepository;
        AccountService accountService = new AccountService(new AccountRepository());
        AccountHolderService accountHolderService = new AccountHolderService(new AccountHolderRepository());


        OverdraftService overdraftService = new OverdraftService(new OverdraftRepository());
        LoanService loanService = new LoanService(new LoanRepository());
        public static Manager loggedInManager;

        private readonly ManagerRepository _managerRepository;
        public ManagerService(ManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        //public ManagerRepository(ManagerRepository managerRepository)
        //{
        //    _managerRepository = managerRepository;
        //}

        public ManagerService()
        {
        }

        public int CreateManager(string firstName, string lastName, string middleName, string email, string password, string checkPassword)
        {

            {
                int managerId = _managerRepository.CreateManager(firstName, lastName, middleName, email, password);

                Console.WriteLine($"Manager with Name {firstName} Created Succesfully");
                Console.ReadKey();

                return managerId;


            }
           



        }
        public void LogoutAccountManager()
        {
            loggedInManager = null;
            
        }

        public Manager FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<AccountHolder> ListAccountHolders()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAccountHolder(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccountHolder(AccountHolder accountHolder)
        {
            throw new NotImplementedException();
        }
        public int LogInManager(string userEmail)
        {



            Manager manager = _managerRepository.FindByEmail(userEmail);


            try
            {
                if (manager == null)
                {
                    throw new Exception($"Account with email {userEmail} does not exist");
                }

                else
                {

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    if (password.Equals(manager.Password))
                    {
                        return manager.Id;
                    }

                    else
                    {
                        throw new Exception("Invalid password");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;

            }
            finally
            {

            }
        }

        public void  ListOfAccountHolders()
        {
            List<AccountInfo> accountInfos = accountHolderService.GetAllAccountInfos();
            foreach (var accountInfo in accountInfos)
            {
                Console.WriteLine($"{accountInfo.FirstName} {accountInfo.MiddleName} {accountInfo.LastName}  {accountInfo.AccountNumber} {accountInfo.Address} {accountInfo.AccountStatus}  {accountInfo.DateOfBirth}");
            }

            
           
        }

        public void ListLoans()
        {
            List<Loan> loans = loanService.GetAllLoans();
            foreach (var loan in loans)
            {
                Console.WriteLine($" {loan.Amount} {loan.AmountLeft} {loan.LoanDate}");
            }
            {

            }
        }

        public void ListAllOverdrafts()
        {
            List<Overdraft> overdrafts = overdraftService.ListAllOverdrafts();
            foreach (var overdraft in overdrafts)
            {
                Console.WriteLine($"{overdraft.Amount} {overdraft.AmountLeft} {overdraft.OverdraftDate}");
            }
        }

        
    }
}
