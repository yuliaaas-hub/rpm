using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_8.Mediator;

namespace lab_8.State
{
    public class NewState: IDocumentState
    {
        public void Print(Document document) {
            Console.WriteLine("Запрос печати");
            document.SetState(new PrintingState());


        }
            
        public void AddToQueue(Document document) {
            Console.WriteLine("Добавление во время невозможно.");
            //throw new NotImplementedException();
            document.Mediator?.Notify(document, "AddToQueue", document);
        }
            
        public void CompletePrinting(Document document)
        {
            Console.WriteLine("Печать завершена успешно");
            document.SetState(new DoneState());
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("Произошла ошибка печати");
            document.SetState(new ErrorState());
        }

        public void Reset(Document document) =>
            Console.WriteLine("Нельзя сбросить во время печати");
    }
}
