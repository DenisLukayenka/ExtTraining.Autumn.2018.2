using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Fabrics
{
    /// <summary>
    /// Abstract factory to create new <see cref="Printer"/> object.
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract  Printer CreatePrinter(string name, string model);
    }
}
