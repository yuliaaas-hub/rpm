    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_8.State;

namespace lab_8.Mediator
{
    // КОНКРЕТНЫЙ КОЛЛЕГА: Принтер
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; } = false;

        public void StartPrint(Document document)
        {

            Console.WriteLine($" [Принтер] Физическая печать'{document.Title}'...");
        
            if (SimulateFailure)
            {
                SimulateFailure = false;
                //Принтер не меняет состояние документа сам!
                //Он просто сообщает посреднику: "Я сломался при печати вотэтого документа"
                Mediator.Notify(this, "PrintFailed", document);
            }
            else
            {
                // Принтер сообщает посреднику: "Я успешно напечатал"
                Mediator.Notify(this, "PrintSuccess", document);
            }
        }
    }
}
