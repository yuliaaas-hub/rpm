using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class GamingComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 7 7800X3D")
                .WithRAM(32)
                .WithGPU("NVIDIA GeForce RTX 4070 Ti")
                .WithComponent("Mechanical RGB Keyboard")
                .WithComponent("Gaming Mouse")
                .WithComponent("27\" 144Hz Monitor")
                .WithComponent("RGB Case Fans")
                .WithComponent("Liquid Cooling")
                .Build();
        }
    }

}
