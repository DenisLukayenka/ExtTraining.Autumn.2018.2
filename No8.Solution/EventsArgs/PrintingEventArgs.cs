using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.EventsArgs
{
    /// <summary>
    /// Class with info to logging.
    /// </summary>
    public class PrintingEventArgs : EventArgs
    {
        public PrintingEventArgs(string name, string model, int count)
        {
            Name = name;
            Model = model;
            CountSymbols = count;
        }

        public PrintingEventArgs(Printer printer, int count)
        {
            Name = printer.Name;
            Model = printer.Model;
            CountSymbols = count;
        }

        /// <summary>
        /// Name of printer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Model of printer.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Count of symbols to print.
        /// </summary>
        public int CountSymbols { get; set; }
    }
}
