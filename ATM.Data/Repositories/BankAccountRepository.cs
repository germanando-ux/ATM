using ATM.Domain;
using ATM.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        public Task<BankAccount?> GetByAccountNumberAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
