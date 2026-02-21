using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ATM.Domain
{
    public class Person
    {
        public string DNI { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Pin { get; private set; }

        private Person() { }

        public Person(string dni, string firstName, string lastName, string pin) 
        {
            DNI = dni;
            FirstName = firstName;
            LastName = lastName;
            Pin = pin;

        }
    }


}
