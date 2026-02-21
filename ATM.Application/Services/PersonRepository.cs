using ATM.Application.Interface;
using ATM.Data.Data;
using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Application.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ATMDbContext _context;

        public PersonRepository(ATMDbContext context) => _context = context;
        public async Task<Person?> GetByDniAsync(string dni)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Dni == dni);
        }
    }
}
