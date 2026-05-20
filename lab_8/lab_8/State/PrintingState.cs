using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8.State
{
    public class PrintingState: IDocumentState
    {
        public void Print(Document document) =>
            Console.WriteLine("Документ уже печатается");
        public void AddToQueue(Document document) =>
            Console.WriteLine("Добавление во время невозможно.");
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
