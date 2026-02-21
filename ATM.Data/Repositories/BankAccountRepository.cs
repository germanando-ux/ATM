using ATM.Data.Data;
using ATM.Domain;
using ATM.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ATM.Data.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ATMDbContext _context;

        public BankAccountRepository(ATMDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca la cuenta y carga explícitamente al dueño (Person).
        /// </summary>
        public async Task<BankAccount?> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.BankAccounts.Include(a => a.Owner).FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Marca la entidad como modificada y persiste en la BBDD en memoria.
        /// </summary>
        public async Task UpdateAsync(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);

            await _context.SaveChangesAsync();
        }


    }
}
