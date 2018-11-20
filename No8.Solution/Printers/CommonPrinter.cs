using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class CommonPrinter : Printer
    {
        public CommonPrinter(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public override void Print(FileStream fileStream)
        {
            if (fileStream is null)
            {
                throw new ArgumentNullException(nameof(fileStream) + " can't be null.");
            }

            for (int i = 0; i < fileStream.Length; i++)
            {
                Console.WriteLine(fileStream.ReadByte());
            }
        }
    }
}
