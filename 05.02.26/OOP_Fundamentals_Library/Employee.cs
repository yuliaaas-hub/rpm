namespace OOP_Fundamentals_Library
{
    public class Employee  : Employer
    {
        public Employee(string name, int age, string position, decimal salary)
            : base(name, age, position, salary)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Employee: {Name}, {Age} years old, Position: {Position}");
        }
    }
}
