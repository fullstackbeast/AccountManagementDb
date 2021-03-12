using System.Collections.Generic;
using BankManagementSystemDB.Domain.Repository;

namespace BankManagementSystemDB.Domain.Service
{
    public class OverdraftService
    {
        private readonly OverdraftRepository OverdraftRepository;

        public OverdraftService(OverdraftRepository overdraftRepository)
        {
            OverdraftRepository = overdraftRepository;
        }

        public void GetOverdraft(int accountHolderId, double amount, double amountLeft){

            Overdraft newOverdraft = new Overdraft(accountHolderId, amount, amountLeft);

            OverdraftRepository.Create(newOverdraft);
        }

        public Overdraft FindActiveOverdraft(List<Overdraft> allOverdrafts)
        {
            return allOverdrafts.Find(x => x.Status == 1);
        }

        public bool HasActiveOverdraft(int accountHolderId){
            List<Overdraft> allOverdrafts = OverdraftRepository.FindOverdrafts(accountHolderId);
            return FindActiveOverdraft(allOverdrafts) != null;
        }

        public void PayOverDraft(int accountHolderId, double amount){
            
            List<Overdraft> allOverdrafts = OverdraftRepository.FindOverdrafts(accountHolderId);
            Overdraft activeoverdraft = FindActiveOverdraft(allOverdrafts);

            activeoverdraft.AmountLeft -= amount;

            if(activeoverdraft.AmountLeft <= 0) activeoverdraft.AmountLeft = 0;
            if(activeoverdraft.AmountLeft == 0) activeoverdraft.Status = 0;

            OverdraftRepository.Update(activeoverdraft);
        }
        public List<Overdraft> ListAllOverdrafts()
        {

            return OverdraftRepository.ListAllOverdrafts();
        }
    }
}