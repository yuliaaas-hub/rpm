using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class OfficeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i3-12100")
                .WithRAM(8)
                .WithGPU("Intel UHD Graphics 730")
                .WithComponent("Office Keyboard")
                .WithComponent("Office Mouse")
                .WithComponent("24\" Monitor")
                .Build();
        }
    }
}
