
using ATM.Application.Interface;
using ATM.Data.Data;
using ATM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ATMDbContext _context;

        public PersonRepository(ATMDbContext context)
        {
            _context = context;
        }
        public async Task<Person?> GetByDniAsync(string dni)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.DNI == dni);
        }
    }
}
