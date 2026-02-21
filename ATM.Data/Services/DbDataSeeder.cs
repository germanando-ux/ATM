using ATM.Data.Data;
using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data.Services
{
    /// <summary>
    /// Clase encargada de la carga inicial de datos en la base de datos en memoria.
    /// </summary>
    public static class DbDataSeeder
    {
        public static void Seed(ATMDbContext context)
        {
            if (context.BankAccounts.Any())
            {
                return;
            }

            var person = new Person("1", "Atilano", "Ceferino");
            var account = new BankAccount("ES1", person, 5000);

            context.Persons.Add(person);
            context.BankAccounts.Add(account);
            context.SaveChanges();

            person = new Person("2", "Pepe", "Gotera");
            account = new BankAccount("ES2", person, 8000);

            context.Persons.Add(person);
            context.BankAccounts.Add(account);
            context.SaveChanges();

            person = new Person("3", "Filemón", "Pi");
            account = new BankAccount("ES3", person, 12000);

            context.Persons.Add(person);
            context.BankAccounts.Add(account);
            context.SaveChanges();


        }
    }
}
