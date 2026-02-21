using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public Person Owner { get; private set; }

        public BankAccount(string accountNumber,Person owner, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Owner = owner;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 3000)
            {
                throw new ArgumentException("No se puede ingresar más de 3000 EUR en una operación.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("El monto a depositar debe ser positivo y mayor que 0.");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 1000)
            {
                throw new ArgumentException("No se puede retirar más de 1000 EUR en una operación.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("El monto a retirar debe ser positivo y mayor que 0.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Fondos insuficientes.");
            }
            Balance -= amount;
        }
    }
}
