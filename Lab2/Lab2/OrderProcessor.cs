using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Fundamentals
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
    }

    public interface IPaymentService
    {
        bool ProcessPayment(string paymentMethod, decimal amount);
    }

    public interface IInventoryService
    {
        void UpdateInventory(List<string> items);
    }

    public interface IReportService
    {
        void GenerateMonthlyReport(IEnumerable<Order> orders);
        void ExportToExcel(IEnumerable<Order> orders, string filePath);
    }

    public class OrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentService _paymentService;
        private readonly IInventoryService _inventoryService;
        private readonly IReportService _reportService;

        public OrderProcessor(
            IOrderRepository orderRepository,
            IPaymentService paymentService,
            IInventoryService inventoryService,
            IReportService reportService)
        {
            _orderRepository = orderRepository;
            _paymentService = paymentService;
            _inventoryService = inventoryService;
            _reportService = reportService;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
            Console.WriteLine($"Order {order.Id} added");
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                Console.WriteLine($"Order {orderId} not found");
                return;
            }

            if (order.TotalAmount <= 0)
                throw new ArgumentException("Invalid order amount");

            _paymentService.ProcessPayment(order.PaymentMethod, order.TotalAmount);
            _inventoryService.UpdateInventory(order.Items);

            Console.WriteLine($"Order {orderId} processed successfully");
        }

        public void GenerateMonthlyReport()
        {
            var orders = _orderRepository.GetAll();
            _reportService.GenerateMonthlyReport(orders);
        }

        public void ExportToExcel(string filePath)
        {
            var orders = _orderRepository.GetAll();
            _reportService.ExportToExcel(orders, filePath);
        }
    }
}