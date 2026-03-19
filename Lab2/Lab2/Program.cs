using Lab2;
using SOLID_Fundamentals;

namespace SOLID_App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Тест ISP: CustomerPortal использует только нужные интерфейсы
            var customerPortal = new CustomerPortal();
            var order = new Order
            {
                Id = 1,
                TotalAmount = 100m,
                CustomerEmail = "test@example.com",
                CustomerPhone = "+1234567890",
                Items = new List<string> { "Item1", "Item2" }
            };

            customerPortal.CreateOrder(order);
            customerPortal.SendNotification(order, "Your order is confirmed");

            // Тест OCP: Добавление новой стратегии без изменения кода калькулятора
            var calculator = new DiscountCalculator();
            Console.WriteLine($"\nVIP discount: {calculator.CalculateDiscount("VIP", 1000)}");
            Console.WriteLine($"Standard shipping: {calculator.CalculateShippingCost("Standard", 5, "USA")}");

            // Тест DIP: Внедрение зависимостей
            var messageServices = new IMessageService[] { new EmailService(), new SmsService() };
            var orderService = new OrderService(messageServices);
            orderService.PlaceOrder(order);

            // Тест LSP: Bank работает только с IWithdrawable
            var savings = new SavingsAccount();
            savings.Deposit(500);

            var bank = new Bank();
            Console.WriteLine($"\nBank test:");
            bank.ProcessWithdrawal(savings, 200);  // Успех
            bank.ProcessWithdrawal(savings, 300);  // Неудача: мин. баланс

            // FixedDepositAccount НЕ передаётся в ProcessWithdrawal (нет IWithdrawable)
            var fixedDeposit = new FixedDepositAccount(DateTime.Now.AddDays(30));
            fixedDeposit.Deposit(1000);
            // bank.ProcessWithdrawal(fixedDeposit, 100); // ОШИБКА КОМПИЛЯЦИИ — правильно!

            Console.ReadKey();
        }
    }
}