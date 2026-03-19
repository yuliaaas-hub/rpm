using SOLID_Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface INotificationService
    {
        void SendNotification(Order order, string message);
        void GenerateInvoice(Order order);
    }
}
