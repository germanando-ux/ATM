using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain.Interface
{
    /// <summary>
    /// Define el contrato para el acceso y persistencia de las cuentas bancarias.
    /// </summary>
    public interface IBankAccountRepository
    {
        /// <summary>
        /// Obtiene una cuenta bancaria por su número de cuenta de forma asíncrona.
        /// </summary>
        /// <param name="accountNumber">El número identificador de la cuenta.</param>
        /// <returns>La instancia de <see cref="BankAccount"/> encontrada o null si no existe.</returns>
        Task<BankAccount?> GetByAccountNumberAsync(string accountNumber);

        /// <summary>
        /// Actualiza los cambios realizados en una cuenta bancaria (como el saldo).
        /// </summary>
        /// <param name="account">La instancia de la cuenta con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task UpdateAsync (BankAccount bankAccount);
        
    }
}
