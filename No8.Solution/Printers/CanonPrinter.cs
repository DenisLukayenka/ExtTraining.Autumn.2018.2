//-----------------------------------------------------------------------
// <copyright file="CanonPrinter.cs" company="Dream Solution">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Denis Lukayenka</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    /// <summary>
    /// Class of canon printer.
    /// </summary>
    public class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        public CanonPrinter(string model) : this()
        {
            this.Model = model;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        private CanonPrinter()
        {
            this.Name = "Canon";
        }

        /// <summary>
        /// Fake method to print.
        /// </summary>
        /// <param name="stream">
        /// Stream argument.
        /// </param>
        protected override void PrintLogic(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}
