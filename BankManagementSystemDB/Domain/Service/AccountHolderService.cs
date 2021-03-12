using BankManagementSystemDB.Domain.Repository;
using BankManagementSystemDB.Interface.Service;
using BankManagementSystemDB.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystemDB.Domain.Service
{
    class AccountHolderService : IAccountHolderService
    {
        private readonly AccountHolderRepository _accountHolderRepository;
        AccountService accountService = new AccountService(new AccountRepository());
        

        OverdraftService OverdraftService = new OverdraftService(new OverdraftRepository());
        public static AccountHolder loggedInAccountHolder;

        public AccountHolderService(AccountHolderRepository accountHolderRepository)
        {
            _accountHolderRepository = accountHolderRepository;
        }

        public bool CreateAccountHolder(string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password, string checkPassword)
        {
            if (password.Equals(checkPassword))
            {
                int accountHolderId = _accountHolderRepository.CreateAccountHolder(firstName, lastName, middleName, dateOfBirth, email, phoneNumber, address, password);

                if (accountHolderId != 0)
                {
                    return accountService.Create(accountHolderId);
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public void DisplayAll()
        {
            throw new NotImplementedException();
        }

        public void SaveMoney()
        {

            Console.Clear();
            Console.WriteLine("     ACCOUNT DEPOSIT MENU");
            Console.Write("How Much Do You Want To Save: ");

            double amountToSave = Convert.ToDouble(Console.ReadLine());

            if (OverdraftService.HasActiveOverdraft(loggedInAccountHolder.Id))
            {
                OverdraftService.PayOverDraft(loggedInAccountHolder.Id, amountToSave);
            }

            accountService.SaveMoney(amountToSave, loggedInAccountHolder.Id);

            GetAccountDetails(loggedInAccountHolder.Email);

        }

        public void Transfermoney(string accountNumber, double amountToTransfer)
        {
            accountService.Transfer(accountNumber, amountToTransfer);
        }

        public void WithdrawMoney(double amountTOWithdraw)
        {

            accountService.WithdrawMoney(amountTOWithdraw);
            Console.WriteLine($"Withdrawal of {amountTOWithdraw} successful");

        }

        public void ChangePassword()
        {
            Console.Clear();
            Console.WriteLine("    Update Password menu");
            Console.Write("  Enter Old Password : ");
            string pass = Console.ReadLine();
            if (pass == loggedInAccountHolder.Password)
            {
                Console.Write("  Enter New Password : ");
                string newPass = Console.ReadLine();
                Console.Write("  Confirm New Password : ");
                string confirmPass = Console.ReadLine();

                if (confirmPass != newPass)
                {
                    Console.WriteLine("Password Update Failed");
                }
                else
                {
                    loggedInAccountHolder.Password = newPass;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                }
            }
        }

        public void UpdateAccountHolderDetails(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Write("Enter new firstName: ");
                    string newFirstName = Console.ReadLine();
                    loggedInAccountHolder.FirstName = newFirstName;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                    break;
                case "2":
                    Console.Write("Enter new lastName: ");
                    string newlastName = Console.ReadLine();
                    loggedInAccountHolder.LastName = newlastName;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                    break;
                case "3":
                    Console.Write("Enter new middleName: ");
                    string newMiddleName = Console.ReadLine();
                    loggedInAccountHolder.MiddleName = newMiddleName;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                    break;
                case "4":
                    Console.Write("Enter new PhoneNUmber: ");
                    string newPhoneNumber = Console.ReadLine();
                    loggedInAccountHolder.PhoneNumber = newPhoneNumber;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                    break;
                case "5":
                    Console.Write("Enter new Address: ");
                    string newAddress = Console.ReadLine();
                    loggedInAccountHolder.Address = newAddress;
                    _accountHolderRepository.UpdateAccountHolder(loggedInAccountHolder);
                    break;

                default:
                    break;
            }
        }


        public void GetOverdraft(double amount)
        {

            if (OverdraftService.HasActiveOverdraft(loggedInAccountHolder.Id))
            {
                Console.WriteLine("You currently have an unpaid overdraft");
                return;
            }

            double overdraftAmountLeft = amount - AccountService.loggedInAccount.AccountBalance;
            accountService.WithdrawMoney(amount);
            OverdraftService.GetOverdraft(loggedInAccountHolder.Id, amount, overdraftAmountLeft);
            GetAccountDetails(loggedInAccountHolder.Email);

        }


        public void changePin()
        {

            if (AccountService.loggedInAccount.Pin != 0)
            {
                if (!ComparePassword()) return;
            }

            Console.Write("Enter your new pin: ");
            int newPin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Confirm pin: ");
            int confirmnewPin = Convert.ToInt32(Console.ReadLine());


            if (newPin == confirmnewPin)
            {
                accountService.ChangePin(newPin);
            }



        }

        public bool ComparePassword()
        {
            Console.Write("Enter your password: ");
            string enteredpassword = Console.ReadLine();
            return enteredpassword.Equals(loggedInAccountHolder.Password);
        }


        public AccountHolder FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAccountDetails(string email)
        {
            AccountInfo infos = _accountHolderRepository.GetAccountInfo(email);

            loggedInAccountHolder = new AccountHolder(infos.AccountHolderId, infos.FirstName, infos.LastName, infos.MiddleName, infos.Email, infos.Password, infos.DateOfBirth, infos.PhoneNumber, infos.Address);
            AccountService.loggedInAccount = new Account(infos.AccountHolderId, infos.AccountNumber, infos.AccountBalance, infos.Pin, infos.AccountStatus);
        }

        public List<AccountInfo> GetAllAccountInfos()
        {
            List<AccountInfo> accountInfos = _accountHolderRepository.GetAllAccountHolders();
          
            return accountInfos;
        }

        public List<AccountHolder> ListAccountHolders()
        {
            throw new NotImplementedException();
        }

        public int LogInAccountholder(string userEmail)
        {



            AccountHolder accountHolder = _accountHolderRepository.FindByEmail(userEmail);


            try
            {
                if (accountHolder == null)
                {
                    throw new Exception($"Account with email {userEmail} does not exist");
                }

                else
                {

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    if (password.Equals(accountHolder.Password))
                    {
                        return accountHolder.Id; 
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

        public void LogoutAccountholder()
        {
            loggedInAccountHolder = null;
            AccountService.loggedInAccount = null;
        }

        public bool RemoveAccountHolder(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccountHolder(int id, string firstName, string middleName, string lastName, string email, string address, string phoneNumber, int pin)
        {
            throw new NotImplementedException();
        }
    }
}
