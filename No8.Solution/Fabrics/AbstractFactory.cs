//-----------------------------------------------------------------------
// <copyright file="AbstractFactory.cs" company="Dream Solution">
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
    /// Abstract factory to create new <see cref="Printer"/> object.
    /// </summary>
    public abstract class AbstractFactory
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
        /// New instance of the <see cref="Printer"/> class.
        /// </returns>
        public abstract Printer CreatePrinter(string name, string model);
    }
}
