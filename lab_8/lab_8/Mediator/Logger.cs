using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8.Mediator
{
    public class Logger: Colleague
    {

        public void WriteMessage(string mes)
        {
            Console.WriteLine($" Logger {mes}");
        }
    }
}
