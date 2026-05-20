using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_8.State;
namespace lab_8.Mediator
{
    public class Dispatcher : Colleague
    {
        public void CommandAddToQueue(Document document)
        {
            // Диспетчер сообщает посреднику: "Добавь документ в очередь"
            Mediator.Notify(this, "AddToQueue", document);
        }

        public void CommandProcessQueue()
        {
            // Диспетчер дает команду посреднику начать обработку очереди
            Mediator.Notify(this, "ProcessQueue");
        }
    }
}
