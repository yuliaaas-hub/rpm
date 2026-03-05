namespace OOP_Fundamentals_Library
{
    
    public class Customer : Person
    {
        public Customer(string name, int age) : base(name, age) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"Customer: {Name}, {Age} years old");
        }
    }       
}
