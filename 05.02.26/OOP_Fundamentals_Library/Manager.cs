namespace OOP_Fundamentals_Library
{
    public class Manager : Employer
    {
        
        private readonly List<Employee> _team = new();
        public IReadOnlyCollection<Employee> Team => _team.AsReadOnly();

        public string Department { get; }

        public Manager(string name, int age, string department, decimal salary)
            : base(name, age, "Manager", salary)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name}, {Age} years old, Department: {Department}");
        }

        public override decimal CalculateBonus(int yearsOfService, bool hasCertification)
        {
            decimal bonus = Salary * 0.2m; 
            if (yearsOfService > 5)
                bonus += 500;
            if (hasCertification)
                bonus += 300;
            return bonus;
            
        }

        public void AddToTeam(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _team.Add(employee);
        }

        public void AssignTaskToEmployee(Employee emp, string task)
        {
            if (string.IsNullOrWhiteSpace(task))
                throw new ArgumentException("Task cannot be empty");
            Console.WriteLine($"Assigning task '{task}' to {emp.Name}");
        }
    }
}
