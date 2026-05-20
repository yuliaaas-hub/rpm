using lab_8.State;
using lab_8.Mediator;


var printer = new Printer();
var queue = new PrintQueue();
var logger = new Logger();
var dispatcher = new Dispatcher();

// 2. СОЗДАНИЕ ПОСРЕДНИКА

var mediator = new PrintSystemMediator(printer, queue, logger);


dispatcher.SetMediator(mediator);

// 3. СОЗДАНИЕ ДОКУМЕНТОВ
var doc1 = new Document("Отчёт_по_практике.pdf");
var doc2 = new Document("Дипломная_работа.docx");
var doc3 = new Document("Фото_на_пропуск.jpg");

doc1.SetMediator(mediator);
doc2.SetMediator(mediator);
doc3.SetMediator(mediator);


// 1: Успешная печать очереди

Console.WriteLine("\n СЦЕНАРИЙ 1: Успешная печать");
Console.WriteLine(new string('-', 40));

doc1.Reset();


dispatcher.CommandAddToQueue(doc1);
dispatcher.CommandAddToQueue(doc2);


dispatcher.CommandProcessQueue(); // Печатает doc1
dispatcher.CommandProcessQueue();


// 2: Ошибка принтера и восстановление

Console.WriteLine("\n СЦЕНАРИЙ 2: Имитация поломки и восстановление");
Console.WriteLine(new string('-', 40));

printer.SimulateFailure = true; // Включаем флаг "поломки"
dispatcher.CommandAddToQueue(doc3);
dispatcher.CommandProcessQueue(); // Попытка печати doc3 -> Принтер сообщит "PrintFailed"

// --- Восстановление ---
Console.WriteLine("\n Восстановление системы после сбоя...");
doc3.Reset();                 // Сбрасываем состояние документа (Error -> New)
printer.SimulateFailure = false; // "Чиним" принтер

dispatcher.CommandAddToQueue(doc3); // Повторно отправляем в очередь
dispatcher.CommandProcessQueue();   // Теперь печать пройдёт успешно

//3: Проверка защиты финального состояния (FSM)

Console.WriteLine("\n СЦЕНАРИЙ 3: Блокировка действий в финальных состояниях");
Console.WriteLine(new string('-', 40));

Console.WriteLine("Попытка управлять уже напечатанным документом (doc1):");
doc1.Print();        // DoneState должен заблокировать
doc1.AddToQueue();   // DoneState должен заблокировать
doc1.FailPrinting(); // DoneState должен заблокировать

Console.WriteLine("\nПопытка печатать документ, который ещё не в очереди (doc3 после успешной печати):");
doc3.Print(); // Тоже заблокирует, т.к. он уже в DoneState

Console.ReadKey(); // Чтобы консоль не закрылась сразу


