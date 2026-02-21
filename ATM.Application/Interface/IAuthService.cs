using ATM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.Interface
{
    public interface IAuthService
    {
        /// <summary>
        /// Valida las credenciales del usuario y genera un token JWT si son correctas.
        /// </summary>
        /// <param name="request">Contiene el DNI y el PIN del usuario.</param>
        /// <returns>El token JWT generado o null si las credenciales son inválidas.</returns>
        Task<string?> AuthenticateAsync(LoginRequest request);
    }
}
