namespace OOP_Fundamentals_Library
{
    public class ReportService
    {
        public void GeneratePersonReport(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Console.WriteLine("\n PERSON REPORT ");
            person.PrintInfo();
            Console.WriteLine("\n");
        }

        public void GenerateSalaryReport(Employer employee, int yearsOfService = 0, bool hasCertification = false)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            Console.WriteLine("\n SALARY REPORT ");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Type: {employee.GetType().Name}");
            Console.WriteLine($"Position: {employee.Position}");
            Console.WriteLine($"Current Salary: {employee.Salary}");
            Console.WriteLine($"Potential Bonus: {employee.CalculateBonus(yearsOfService, hasCertification):0.##}");
            Console.WriteLine("\n");
        }
    }
}
