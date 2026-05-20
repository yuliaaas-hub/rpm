using lab_7;
using lab_7.Strategy;
using lab_7.StrategyTemplateMetod;

class program
{
    static void Main(string[] args)
    {
        EventMonitor monitor = new();
        monitor.OnMetricExceeded += e => Console.WriteLine($"Метрика {e.Data.MetricName} превышена!");

        monitor.CheckMetric("CPU", 95.0, 80.0);
        monitor.CheckMetric("Memory", 28.05, 65.98);
        monitor.CheckMetric("Disk", 46.76, 83.56);

        TextFormatStrategy textStrategy = new TextFormatStrategy();
        JsonFormatStrategy jsonStrategy = new JsonFormatStrategy();

        var textHandler = new ConsoleHandler(textStrategy);
        var jsonHandler = new ConsoleHandler(jsonStrategy);

        monitor.OnMetricExceeded += textHandler.ProcessEvent;
        monitor.OnMetricExceeded += jsonHandler.ProcessEvent;
        Console.WriteLine("\nThe handlers are registered:\n- ConsoleHandler (text format)\n- ConsoleHandler (JSON format)\n");


        ConsoleHandler consoleHandler = new ConsoleHandler(textStrategy);
        FileHandler fileHandler = new FileHandler(textStrategy, "file1.txt");

        MetricData testData = new MetricData("CPU_Usage", 77, 70, DateTime.Now);
        MetricEventArgs testEvent = new MetricEventArgs("Exceeding the threshold", testData);

        consoleHandler.ProcessEvent(testEvent);
        fileHandler.ProcessEvent(testEvent);

    }
}


    
