using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.DTOs
{
    /// <summary>
    /// Representa la respuesta con el estado actual de la cuenta tras una operación.
    /// </summary>
    public class AccountResponseDTO
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string OwnerName { get; set; } = string.Empty;
    }
}
