using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Fundamentals
{
    //  ИНТЕРФЕЙС ДЛЯ СООБЩЕНИЙ 
    public interface IMessageService
    {
        void SendMessage(string recipient, string subject, string body);
        bool Supports(string channel);
    }

    //  РЕАЛИЗАЦИИ 
    public class EmailService : IMessageService
    {
        public bool Supports(string channel) =>
            channel.Equals("email", StringComparison.OrdinalIgnoreCase);

        public void SendMessage(string recipient, string subject, string body)
        {
            Console.WriteLine($"Sending email to {recipient}: {subject}");
        }
    }

    public class SmsService : IMessageService
    {
        public bool Supports(string channel) =>
            channel.Equals("sms", StringComparison.OrdinalIgnoreCase);

        public void SendMessage(string recipient, string subject, string body)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {body}");
        }
    }

    //  OrderService с внедрением зависимостей 
    public class OrderService
    {
        private readonly IEnumerable<IMessageService> _messageServices;

        public OrderService(IEnumerable<IMessageService> messageServices)
        {
            _messageServices = messageServices ?? throw new ArgumentNullException(nameof(messageServices));
        }

        public void PlaceOrder(Order order)
        {
            SendNotification(order.CustomerEmail, "email", "Order Confirmation", "Your order has been placed");
            SendNotification(order.CustomerPhone, "sms", "Order Confirmation", "Your order has been placed");
        }

        private void SendNotification(string recipient, string channel, string subject, string body)
        {
            var service = _messageServices.FirstOrDefault(s => s.Supports(channel));
            service?.SendMessage(recipient, subject, body);
        }
    }

    //  NotificationService с внедрением зависимостей 
    public class NotificationService
    {
        private readonly IMessageService _emailService;

        public NotificationService(IMessageService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public void SendPromotion(string email, string promotion)
        {
            _emailService.SendMessage(email, "Special Promotion", promotion);
        }
    }
}