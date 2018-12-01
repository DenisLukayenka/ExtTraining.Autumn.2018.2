//-----------------------------------------------------------------------
// <copyright file="Factory.cs" company="Dream Solution">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Denis Lukayenka</author>
//-----------------------------------------------------------------------

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
        /// <summary>
        /// Method to create new instance of <see cref="Printer"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of printer.
        /// </param>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        /// <returns>
        /// New instance of <see cref="Printer"/> class.
        /// </returns>
        public override Printer CreatePrinter(string name, string model)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name) + " is null.");
            }

            if (model is null)
            {
                throw new ArgumentNullException(nameof(model) + " is null.");
            }

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
