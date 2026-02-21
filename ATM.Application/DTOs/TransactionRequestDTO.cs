using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.DTOs
{
    /// <summary>
    /// Representa la solicitud para realizar una operación de ingreso o retiro.
    /// </summary>
    public class TransactionRequestDTO
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
