using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Domain
{
    public class Person
    {
        public string DNI { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

       
        public Person(string DNI, string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }


}
