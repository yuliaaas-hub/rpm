using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class ComputerBuilder
    {
        private Computer _computer;

        public ComputerBuilder()
        {
            _computer = new Computer();
        }

        public ComputerBuilder WithCPU(string cpu)
        {
            _computer.CPU = cpu;
            return this; // Возвращаем this для цепочки вызовов (Fluent Interface)
        }

        public ComputerBuilder WithRAM(int ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public ComputerBuilder WithGPU(string gpu)
        {
            _computer.GPU = gpu;
            return this;
        }

        public ComputerBuilder WithComponent(string component)
        {
            _computer.AdditionalComponents.Add(component);
            return this;
        }

        public ComputerBuilder WithComponents(IEnumerable<string> components)
        {
            if (components != null)
            {
                foreach (var component in components)
                {
                    _computer.AdditionalComponents.Add(component);
                }
            }
            return this;
        }

        public Computer Build()
        {
            var result = _computer;
            _computer = new Computer(); // Сброс для повторного использования билдера
            return result;
        }
    }
}
