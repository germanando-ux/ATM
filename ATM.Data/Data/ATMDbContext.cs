using ATM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data.Data
{

    public class ATMDbContext: DbContext
    {
        public DbSet<Person> Persons => Set<Person>();

        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options)
        {
        }

    }
}
