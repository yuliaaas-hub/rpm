using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8.State
{
    public class DoneState: IDocumentState
    {
        public void Print(Document document)=>
            Console.WriteLine("Документ уже напечатан");
        public void AddToQueue(Document document) =>
            Console.WriteLine("Финальное состояние. Добавление невозможно.");
        public void CompletePrinting(Document document) =>
            Console.WriteLine("Уже в финальном состоянии");
        public void FailPrinting(Document document) =>
            Console.WriteLine("Документ уже напечатан");
        public void Reset(Document document) =>
            Console.WriteLine("Документ завершен");

    }
}
