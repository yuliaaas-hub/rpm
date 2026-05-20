using lab_7.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7.StrategyTemplateMetod
{
    public class ConsoleHandler : EventHandlerBase
    {
        // Мы принимаем стратегию и сразу передаём её в базовый класс через : base(strategy)
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }
        
        protected override string FormatMessage(string eventtype, object data)
        {
            string rawMes = $"{eventtype}: {data}";
            return _formatStrategy.Format(rawMes, DateTime.Now);
        }
        protected override void SendMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[ConsoleHandler] The notification was sent to the console in {DateTime.Now:HH:mm:ss}");
        }
    }
}
