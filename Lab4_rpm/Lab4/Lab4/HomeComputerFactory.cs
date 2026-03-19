using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class HomeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5-13400")
                .WithRAM(16)
                .WithGPU("NVIDIA GeForce RTX 3060")
                .WithComponent("Wireless Keyboard")
                .WithComponent("Wireless Mouse")
                .WithComponent("24\" IPS Monitor")
                .WithComponent("Webcam")
                .Build();
        }
    }
}
