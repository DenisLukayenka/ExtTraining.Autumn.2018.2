using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            Name = "Epson";
        }

        public EpsonPrinter(string model) : this()
        {
            Model = model;
        }

        protected override void PrintLogic(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}
