using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Fundamentals_Library
{
    public abstract class Employer : Person
    {
        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public string Position { get; protected set; }

        protected Employer(string name, int age, string position, decimal salary)
            : base(name, age)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Salary = salary;
        }

        public virtual void IncreaseSalary(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            Salary += amount;
        }

        public virtual decimal CalculateBonus(int yearsOfService, bool hasCertification)
        {
            decimal bonus = Salary * 0.1m; 
            if (yearsOfService > 5)
                bonus += 500;
            if (hasCertification)
                bonus += 300;
            return bonus;
        }

        public virtual void ProcessPayroll()
        {
            Console.WriteLine($"Processing payroll for {Name}: {Salary}");
        }
    }
}
