//-----------------------------------------------------------------------
// <copyright file="PrinterManager.cs" company="Dream Solution">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Denis Lukayenka</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using No8.Solution.Fabrics;
using No8.Solution.Loggers;
using No8.Solution.Printers;
using No8.Solution.Repository;

namespace No8.Solution
{
    /// <summary>
    /// Main to class with logic to printing.
    /// </summary>
    public class PrinterManager
    {
        /// <summary>
        /// Field with instance of <see cref="PrinterManager"/> class.
        /// </summary>
        private static readonly Lazy<PrinterManager> Instance =
            new Lazy<PrinterManager>(() => new PrinterManager());

        /// <summary>
        /// Instance of <see cref="IRepository"/> class.
        /// </summary>
        private IRepository repository;

        /// <summary>
        /// Instance of <see cref="ILogger"/> class.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Prevents a default instance of the <see cref="PrinterManager"/> class from being created.
        /// </summary>
        private PrinterManager() : this(new Logger(), new FakeRepository())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterManager"/> class.
        /// </summary>
        /// <param name="logger">
        /// Instance of <see cref="ILogger"/> class.
        /// </param>
        /// <param name="repository">
        /// Instance of <see cref="IRepository"/> class.
        /// </param>
        private PrinterManager(ILogger logger, IRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Gets Instance of class.
        /// </summary>
        public static PrinterManager GetInstance => Instance.Value;

        /// <summary>
        /// Method to add new <see cref="Printer"/> to repository.
        /// </summary>
        /// <param name="printer">
        /// Printer to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public void Add(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }

            if (this.repository.Contains(printer))
            {
                throw new InvalidOperationException($"Printer {printer} is already exist.");
            }

            printer.StartPrint += (sender, args) =>
                this.logger.Log($"Printer {args.Name} {args.Model} start printing at {args.Time}.");

            printer.FinishPrint += (sender, args) =>
                this.logger.Log($"Printer {args.Name} {args.Model} finish printing at {args.Time}.");

            this.repository.Add(printer);
        }

        /// <summary>
        /// Method to remove <see cref="Printer"/> from repository.
        /// </summary>
        /// <param name="printer">
        /// Printer to remove.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public void Remove(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }

            this.repository.Remove(printer);
        }

        /// <summary>
        /// Method to get all elements of printers.
        /// </summary>
        /// <returns>
        /// List of <see cref="Printer"/>.
        /// </returns>
        public IReadOnlyCollection<Printer> GetList() => this.repository.GetPrinters();

        /// <summary>
        /// Method to print.
        /// </summary>
        /// <param name="printer">
        /// Printer which should to print.
        /// </param>
        /// <param name="filePath">
        /// Path to file.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public void Print(Printer printer, string filePath)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " printer object can't be null.");
            }

            if (!this.repository.Contains(printer))
            {
                throw new InvalidOperationException("Repository does not contain printer" + nameof(printer));
            }

            using (FileStream stream = File.OpenRead(filePath))
            {
                this.repository.GetPrinters().First(p => p.Equals(printer)).Print(stream);
            }
        }
    }
}