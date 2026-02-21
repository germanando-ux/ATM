using ATM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data.Data
{

    public class ATMDbContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();

        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.DNI);
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Pin).IsRequired().HasMaxLength(4);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(b => b.AccountNumber);

                entity.Property(b => b.Balance).IsRequired();

                entity.HasOne(b => b.Owner)
                      .WithMany()
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
