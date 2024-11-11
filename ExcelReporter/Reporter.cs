using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDefinitions;

namespace ExcelReporter
{
    public class Reporter : AbstractExcelReporter
    {
        public override string Name { get; } = "Эксель репортер";
        public override byte[] Generate()
        {
            throw new NotImplementedException();
        }
    }
}
