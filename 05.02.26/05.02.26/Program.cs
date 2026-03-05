namespace OOP_Fundamentals_Library
{
    internal class ProgramExample
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(" Запуск демонстрации рефакторинга ООП\n");

            // 1. Создание объектов
            var customer = new Customer("John", 30);
            var employee = new Employee("Alice", 25, "Developer", 50000m);
            var manager = new Manager("Bob", 40, "IT", 80000m);

            // 2. Проверка полиморфизма (PrintInfo)
            Console.WriteLine(" Информация о людях:");
            customer.PrintInfo();
            employee.PrintInfo();
            manager.PrintInfo();

            // 3. Проверка наследования и инкапсуляции
            Console.WriteLine("\n Менеджер управляет командой:");
            manager.AddToTeam(employee);
            manager.AssignTaskToEmployee(employee, "Refactor the code");

            // 4. Проверка работы сервисов
            Console.WriteLine("\n Обработка зарплаты:");
            var payroll = new PayrollSystem();
            payroll.ProcessSalary(employee);
            payroll.ProcessSalary(manager, 2000);

            // 5. Генерация отчетов
            Console.WriteLine("\n Отчёты:");
            var reporter = new ReportService();
            reporter.GeneratePersonReport(customer);
            reporter.GeneratePersonReport(employee);
            reporter.GenerateSalaryReport(manager, yearsOfService: 6, hasCertification: true);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
