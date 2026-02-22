using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain
{
    /// <summary>
    /// Representa una cuenta bancaria dentro del dominio del sistema ATM.
    /// Contiene las reglas de negocio para depósitos y retiros.
    /// </summary>
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public Person Owner { get; private set; }

        private BankAccount() { }

        public BankAccount(string accountNumber,Person owner, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Owner = owner;
        }

        /// <summary>
        /// implementa la lógica de un ingreso de dinero en la cuenta cumpliendo las reglas de negocio.
        /// </summary>
        /// <param name="amount">Cantidad a ingresar.</param>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando el monto es superior a 3000 EUR o no es un valor positivo.
        /// </exception>
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

        /// <summary>
        /// implementa la lógica de una retirada de efectivo de la cuenta cumpliendo las reglas de negocio.
        /// </summary>
        /// <param name="amount">Cantidad a retirar.</param>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando el monto supera los 1000 EUR o no es un valor positivo.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Se lanza cuando el monto a retirar es mayor al saldo disponible.
        /// </exception>
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
