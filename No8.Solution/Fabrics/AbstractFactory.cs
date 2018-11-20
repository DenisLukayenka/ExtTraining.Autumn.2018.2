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
    internal abstract class AbstractFactory
    {
        /// <summary>
        /// Method to create custom printer.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns>
        /// Returns new object of <see cref="CommonPrinter"/>.
        /// </returns>
        public abstract Printer CreateCommonPrinter(string name, string model);

        /// <summary>
        /// Method to create Epson printer.
        /// </summary>
        /// <returns>
        /// Returns new object of <see cref="EpsonPrinter"/>.
        /// </returns>
        public abstract Printer CreateEpsonPrinter();

        /// <summary>
        /// Method tot create Cannon printer.
        /// </summary>
        /// <returns>
        /// Returns new object of <see cref="CanonPrinter"/>
        /// </returns>
        public abstract  Printer CreateCanonPrinter();
    }
}
