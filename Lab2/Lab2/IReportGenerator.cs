using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface IReportGenerator
    {
        void GenerateReport(DateTime from, DateTime to);
        void ExportToExcel(string filePath);
    }
}
