namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        public void ProcessSalary(Employer employee, decimal defaultIncrease = 1000)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            employee.ProcessPayroll();
            employee.IncreaseSalary(defaultIncrease);

            Console.WriteLine($" Salary processed. New amount: {employee.Salary}");
        }

    }
}
