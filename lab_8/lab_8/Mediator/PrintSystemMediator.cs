using lab_8.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8.Mediator
{
    public class PrintSystemMediator : IMediator
    {
        // Посредник знает всех конкретных коллег
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;
        public PrintSystemMediator(Printer printer, PrintQueue queue, Logger
        logger)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;
            // Посредник подписывает коллег на себя
            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
        }
        // МЕТОД, КОТОРЫЙ РЕАЛИЗУЕТ ВЕСЬ АЛГОРИТМ ВЗАИМОДЕЙСТВИЯ
        public void Notify(Colleague sender, string ev, Document document =
        null)
        {
            switch (ev)
            {
                // Событие от Документа (через State): "Хочу в очередь"
                case "AddToQueue":_queue.EnqueueItem(document);

                break;

                // Событие от Очереди: "Документ добавлен"
                case "Enqueued":_logger.WriteMessage($"Документ '{document.Title}' помещен в очередь.");
                break;
                // Событие от Документа (через State): "Хочу печататься"
                case "RequestPrint":

                    document.SetState(new PrintingState()); // Меняем состояние(FSM)
            
                    var docToPrint = document;
                    // Посредник дает команду принтеру
                    _printer.StartPrint(docToPrint);
                break;

                // Событие от Диспетчера: "Печатай всю очередь"
                case "ProcessQueue":
                    if (_queue.IsEmpty)

                    {

                        _logger.WriteMessage("Очередь пуста.");
                        return;
                    }

                    var nextDoc = _queue.DequeueItem();
                    nextDoc.SetMediator(this); // Важно: документ тоже коллега,даем ему посредника
                    nextDoc.Print(); // Запускаем цепочку State -> Mediator
                    break;
                // Событие от Принтера: "Успех"
                case "PrintSuccess":

                    document.CompletePrinting(); // Посредник дергает State до-кумента
            
                    _logger.WriteMessage($"Успешно напечатан '{document.Title}'.");

                    break;
                // Событие от Принтера: "Ошибка"
                case "PrintFailed":

                    document.FailPrinting(); // Посредник дергает State документа
            
                    _logger.WriteMessage($"ОШИБКА печати '{document.Title}'.");

                break;
            }
        }
    }
}
