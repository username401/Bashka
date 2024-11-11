using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDefinitions
{
    public abstract class AbstractExcelReporter
    {
        public abstract string Name { get; }
        public abstract byte[] Generate();
    }
}
