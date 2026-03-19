using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    public class Computer
    {
        public string CPU { get; set; }
        public int RAM { get; set; } // в ГБ
        public string GPU { get; set; }
        public List<string> AdditionalComponents { get; set; }

        public Computer()
        {
            AdditionalComponents = new List<string>();
        }

        // Конструктор для клонирования
        private Computer(Computer other)
        {
            CPU = other.CPU;
            RAM = other.RAM;
            GPU = other.GPU;
            // Поверхностное копирование списка (ссылка на тот же объект)
            AdditionalComponents = other.AdditionalComponents;
        }

        public void Display()
        {
            Console.WriteLine($"\nComputer Configuration");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine($"GPU: {GPU}");
            Console.WriteLine($"Additional Components:");
            if (AdditionalComponents?.Any() == true)
            {
                foreach (var component in AdditionalComponents)
                {
                    Console.WriteLine($"  - {component}");
                }
            }
            else
            {
                Console.WriteLine("  (none)");
            }
            Console.WriteLine($"\n");
        }

        // === ПОВЕРХНОСТНОЕ КОПИРОВАНИЕ ===
        // Копирует значения полей, но ссылочные типы (List) копируются как ссылки
        public Computer ShallowCopy()
        {
            return new Computer(this);
        }

        // === ГЛУБОКОЕ КОПИРОВАНИЕ ===
        // Создаёт новые экземпляры всех ссылочных полей
        public Computer DeepCopy()
        {
            return new Computer
            {
                CPU = CPU,
                RAM = RAM,
                GPU = GPU,
                AdditionalComponents = AdditionalComponents?.ToList() // новый список с теми же строками
            };
        }

    }
}
