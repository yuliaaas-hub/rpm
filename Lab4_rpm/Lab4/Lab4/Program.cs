using Lab4;

namespace Lab4App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Computer Configurator - Design Patterns Demo \n");

            // === 1. BUILDER PATTERN ===
            Console.WriteLine("1. Creating computer via Builder:");
            var customPC = new ComputerBuilder()
                .WithCPU("Custom CPU")
                .WithRAM(24)
                .WithGPU("Custom GPU")
                .WithComponent("Extra SSD")
                .WithComponent("RGB Lighting")
                .Build();
            customPC.Display();

            // === 2. FACTORY METHOD PATTERN ===
            Console.WriteLine("2. Creating computers via Factories:");

            var officePC = new OfficeComputerFactory().Construct();
            Console.WriteLine("Office PC:");
            officePC.Display();

            var gamingPC = new GamingComputerFactory().Construct();
            Console.WriteLine("Gaming PC:");
            gamingPC.Display();

            var homePC = new HomeComputerFactory().Construct();
            Console.WriteLine("Home PC:");
            homePC.Display();

            // === 3. PROTOTYPE PATTERN: Shallow vs Deep Copy ===
            Console.WriteLine("3. Prototype Pattern - Shallow vs Deep Copy:\n");

            var original = new ComputerBuilder()
                .WithCPU("Test CPU")
                .WithRAM(16)
                .WithGPU("Test GPU")
                .WithComponent("Component A")
                .WithComponent("Component B")
                .Build();

            Console.WriteLine("Original:");
            original.Display();

            // Поверхностное копирование
            var shallowClone = original.ShallowCopy();
            shallowClone.CPU = "Modified CPU (Shallow)";
            shallowClone.AdditionalComponents.Add("New Component (Shallow)");

            Console.WriteLine("After Shallow Copy - Modified Clone:");
            shallowClone.Display();

            Console.WriteLine("Original after Shallow Copy (AdditionalComponents changed!):");
            original.Display(); // ⚠️ Список изменился, потому что ссылка общая!

            // Восстанавливаем оригинал для чистоты эксперимента
            original = new ComputerBuilder()
                .WithCPU("Test CPU")
                .WithRAM(16)
                .WithGPU("Test GPU")
                .WithComponent("Component A")
                .WithComponent("Component B")
                .Build();

            // Глубокое копирование
            var deepClone = original.DeepCopy();
            deepClone.CPU = "Modified CPU (Deep)";
            deepClone.AdditionalComponents.Add("New Component (Deep)");

            Console.WriteLine("After Deep Copy - Modified Clone:");
            deepClone.Display();

            Console.WriteLine("Original after Deep Copy (unchanged):");
            original.Display(); // ✅ Оригинал не изменился!

            // === 4. SINGLETON PATTERN: PrototypeRegistry ===
            Console.WriteLine("4. Singleton Pattern - PrototypeRegistry:\n");

            var registry1 = PrototypeRegistry.Instance;
            var registry2 = PrototypeRegistry.Instance;

            Console.WriteLine($"registry1 == registry2: {ReferenceEquals(registry1, registry2)}");
            Console.WriteLine($"IsSameInstance: {registry1.IsSameInstance(registry2)}\n");

            // Получение прототипа и его модификация
            Console.WriteLine("Getting 'gaming' prototype from registry:");
            var myGamingPC = registry1.GetPrototype("gaming");
            myGamingPC.RAM = 64; // Модифицируем копию
            myGamingPC.AdditionalComponents.Add("Extra NVMe SSD");
            Console.WriteLine("Modified copy:");
            myGamingPC.Display();

            // Проверяем, что оригинал в реестре не изменился
            Console.WriteLine("Getting 'gaming' prototype again (should be original):");
            var freshGamingPC = registry1.GetPrototype("gaming");
            freshGamingPC.Display(); // ✅ RAM = 32, нет "Extra NVMe SSD"

            // === 5. Thread Safety Demo (опционально) ===
            Console.WriteLine("5. Thread Safety Test (10 threads requesting prototypes):");
            var tasks = new System.Threading.Tasks.Task[10];
            var results = new PrototypeRegistry[10];

            for (int i = 0; i < 10; i++)
            {
                int index = i;
                tasks[index] = System.Threading.Tasks.Task.Run(() =>
                {
                    results[index] = PrototypeRegistry.Instance;
                });
            }
            System.Threading.Tasks.Task.WaitAll(tasks);

            var allSame = true;
            for (int i = 1; i < 10; i++)
            {
                if (!ReferenceEquals(results[0], results[i]))
                {
                    allSame = false;
                    break;
                }
            }
            Console.WriteLine($"All threads got same instance: {allSame}\n");

            Console.WriteLine(" Demo Completed ");
            Console.ReadKey();
        }
    }
}