using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.DTOs
{
    /// <summary>
    /// Datos necesarios para solicitar un token de acceso.
    /// </summary>
    public class LoginRequest
    {
        public string Dni { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;
    }
}
