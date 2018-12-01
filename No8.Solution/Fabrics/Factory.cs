using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Fabrics
{
    /// <summary>
    /// Class to creating new printers.
    /// </summary>
    public class Factory : AbstractFactory
    {
        public override Printer CreatePrinter(string name, string model)
        {
            switch (name.ToUpperInvariant())
            {
                case "EPSON":
                    return new EpsonPrinter(model);
                case "CANON":
                    return new CanonPrinter(model);
                default:
                    throw new ArgumentException($"{name} is bad name.");
            }
        }
    }
}
