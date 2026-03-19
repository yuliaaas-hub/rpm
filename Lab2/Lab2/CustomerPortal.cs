using SOLID_Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CustomerPortal : IOrderManagement, INotificationService
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created by customer");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated by customer");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted by customer");
        }

        public void SendNotification(Order order, string message)
        {
            Console.WriteLine($"Notification to customer: {message}");
        }

        public void GenerateInvoice(Order order)
        {
            Console.WriteLine($"Invoice generated for order {order.Id}");
        }
    }
}
