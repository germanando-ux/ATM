using ATM.Application.DTOs;
using ATM.Application.Interface;
using ATM.Domain;
using ATM.Domain.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATM.Application.Services
{
    ///<summary>
    /// Implementación del servicio de autenticación mediante JWT.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IConfiguration _config;

        public AuthService(IPersonRepository personRepository, IConfiguration config)
        {
            _personRepository = personRepository;
            _config = config;
        }

        /// <summary>
        /// Realiza la validación de DNI y PIN contra la base de datos.
        /// </summary>
        public async Task<string?> AuthenticateAsync(LoginRequest request)
        {

            var person = await _personRepository.GetByDniAsync(request.Dni);

           if (person == null || person.Pin != request.Pin)
            {
                return null;
            }


            return GenerateJwtToken(person);
        }

        /// <summary>
        /// Encapsula la lógica de creación del token JWT.
        /// </summary>
        private string GenerateJwtToken(Person person)
        {
            // Leemos la clave desde appsettings.json
            var jwtKey = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing in configuration.");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos los Claims (información que viaja dentro del token)
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, person.DNI),
            new Claim(ClaimTypes.Name, $"{person.FirstName} {person.LastName}"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: "ATM_System",
                audience: "ATM_Users",
                claims: claims,
                expires: DateTime.Now.AddHours(12), // Validez de 2 horas
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
