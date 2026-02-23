using ATM.Application.DTOs;
using ATM.Application.Interface;
using ATM.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.Services
{
    /// <summary>
    /// Servicio de aplicación que coordina las operaciones bancarias.
    /// Se encarga de la orquestación entre el dominio y la persistencia.
    /// </summary>
    public class BankService : IBankService
    {
        private readonly IBankAccountRepository _repository;

        public BankService(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Procesa un ingreso de dinero en una cuenta existente.
        /// </summary>
        /// <param name="request">Datos de la transacción.</param>
        /// <returns>Respuesta con el estado actualizado de la cuenta.</returns>
        /// <exception cref="InvalidOperationException">Lanzada si la cuenta no existe o infringe reglas de dominio.</exception>
        public async Task<AccountResponseDTO> DepositAsync(TransactionRequestDTO request)
        {
            var account = await _repository.GetByAccountNumberAsync(request.AccountNumber);

            if (account == null)
            {
                throw new InvalidOperationException("La cuenta no existe.");
            }

            account.Deposit(request.Amount);

            await _repository.UpdateAsync(account);

            return MapToResponse(account);
        }

        /// <summary>
        /// Procesa un retiro de dinero de una cuenta existente.
        /// </summary>
        /// <param name="request">Datos de la transacción.</param>
        /// <returns>Respuesta con el estado actualizado de la cuenta.</returns>
        /// <exception cref="InvalidOperationException">Lanzada si la cuenta no existe, saldo insuficiente o excede límite de retiro.</exception>
        public async Task<AccountResponseDTO> WithdrawAsync(TransactionRequestDTO request)
        {
            var account = await _repository.GetByAccountNumberAsync(request.AccountNumber);

            if (account == null)
            {
                throw new InvalidOperationException("La cuenta no existe.");
            }

            account.Withdraw(request.Amount);

            await _repository.UpdateAsync(account);

            return MapToResponse(account);
        }


        /// <summary>
        /// Realiza el mapeo manual de una entidad de dominio a un objeto de transferencia de datos (DTO).
        /// </summary>
        /// <param name="account">Entidad de dominio.</param>
        /// <returns>DTO de respuesta.</returns>
        private AccountResponseDTO MapToResponse(ATM.Domain.BankAccount account)
        {
            return new AccountResponseDTO
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                OwnerName = $"{account.Owner.FirstName} {account.Owner.LastName}"
            };
        }
    }
}
