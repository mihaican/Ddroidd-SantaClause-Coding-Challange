using SantaClauseConsoleApp.Core;
using System;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        public Child(string name, DateTime date, int age, Address address, Letter letter, bool isNice=false)
        {
            Name = name;  
            DateOfBirth = date;   
            Address = address;
            Age = age;
            IsNice = isNice;
            Letter = letter;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; } 

        public bool IsNice { get; set; }
        public Letter Letter { get; }

        private bool _sentLetter;
 
    }
    
}
