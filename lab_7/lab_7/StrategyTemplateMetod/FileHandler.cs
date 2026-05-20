using lab_7.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7.StrategyTemplateMetod
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        protected override string FormatMessage(string eventtype, object data)
        {
            string rawMes = $"file  {eventtype}: {data}";
            return _formatStrategy.Format(rawMes, DateTime.Now);
        }
        protected override void SendMessage(string mes)
        {
            File.AppendAllText(_filePath, mes + Environment.NewLine);
            Console.WriteLine(mes);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[FileHandler] Written to a file '{_filePath}'");
        }

    }
}
