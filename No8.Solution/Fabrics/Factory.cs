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
    internal class Factory : AbstractFactory
    {
        /// <summary>
        /// Method tot create Cannon printer.
        /// </summary>
        /// <returns>
        /// Returns new object of <see cref="CanonPrinter"/>
        /// </returns>
        public override Printer CreateCanonPrinter()
        {
            return new CanonPrinter();
        }

        /// <summary>
        /// Method to create custom printer.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns>
        /// Returns new object of <see cref="CommonPrinter"/>.
        /// </returns>
        public override Printer CreateCommonPrinter(string name, string model)
        {
            return new CommonPrinter(name, model);
        }

        /// <summary>
        /// Method to create Epson printer.
        /// </summary>
        /// <returns>
        /// Returns new object of <see cref="EpsonPrinter"/>.
        /// </returns>
        public override Printer CreateEpsonPrinter()
        {
            return new EpsonPrinter();
        }
    }
}
