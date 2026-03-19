using SOLID_Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class AdminPanel : IOrderManagement, IPaymentProcessor, IShippingService,
                              IReportGenerator, IDatabaseManager, INotificationService
    {
        public void CreateOrder(Order order) => Console.WriteLine("Order created by admin");
        public void UpdateOrder(Order order) => Console.WriteLine("Order updated by admin");
        public void DeleteOrder(int orderId) => Console.WriteLine("Order deleted by admin");

        public void ProcessPayment(Order order) => Console.WriteLine("Payment processed by admin");

        public void ShipOrder(Order order) => Console.WriteLine("Order shipped by admin");

        public void SendNotification(Order order, string message) =>
            Console.WriteLine($"Admin notification: {message}");

        public void GenerateInvoice(Order order) =>
            Console.WriteLine($"Admin invoice for order {order.Id}");

        public void GenerateReport(DateTime from, DateTime to) =>
            Console.WriteLine($"Report generated: {from} to {to}");

        public void ExportToExcel(string filePath) =>
            Console.WriteLine($"Exported to {filePath}");

        public void BackupDatabase() => Console.WriteLine("Database backed up");
        public void RestoreDatabase() => Console.WriteLine("Database restored");
    }
}
