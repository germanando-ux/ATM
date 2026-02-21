using ATM.Application.DTOs;
using ATM.Application.Interface;
using ATM.Domain.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ATM.Application.Services
{
    ///<summary>
    /// Implementación del servicio de autenticación mediante JWT.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IBankAccountRepository _repository;
        private readonly IConfiguration _config;

        public AuthService(IBankAccountRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }
        public async Task<string?> AuthenticateAsync(LoginRequest request)
        {
        
            var account = await _repository.GetByAccountNumberAsync(request.AccountNumber);

            // Validación de seguridad
            if (account == null || account.Owner.Dni != request.Dni || account.Owner.Pin != request.Pin)
            {
                return null;
            }

            // 2. Si es válido, generamos el Token
            return GenerateJwtToken(account.Owner.Dni);
        }

        /// <summary>
        /// Genera un token JWT firmado para el usuario.
        /// </summary>
        private string GenerateJwtToken(string dni)
        {
            var jwtKey = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, dni),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("System", "ATM_Tech_Test")
        };

            var token = new JwtSecurityToken(
                issuer: "ATM_System",
                audience: "ATM_Users",
                claims: claims,
                expires: DateTime.Now.AddHours(1), // El token expira en 1 hora
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
