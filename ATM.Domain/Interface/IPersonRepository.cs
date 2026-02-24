using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.Interface
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Obtiene una persona por su DNI para validación de identidad.
        /// </summary>
        Task<Person?> GetByDniAsync(string dni);
    }
}
