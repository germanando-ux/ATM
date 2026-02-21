using ATM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.Interface
{
    /// <summary>
    /// Define las operaciones de negocio disponibles para la gestión bancaria.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Realiza un ingreso en la cuenta especificada.
        /// </summary>
        Task<AccountResponseDTO> DepositAsync(TransactionRequestDTO request);

        /// <summary>
        /// Realiza un retiro de la cuenta especificada.
        /// </summary>
        Task<AccountResponseDTO> WithdrawAsync(TransactionRequestDTO request);
    }
}
