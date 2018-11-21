using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using No8.Solution.EventsArgs;
using No8.Solution.Fabrics;
using No8.Solution.Loggers;
using No8.Solution.Printers;
using No8.Solution.Repository;

namespace No8.Solution.Manager
{
    /// <summary>
    /// Main to class with logic to printing.
    /// </summary>
    public static class PrinterManager
    {
        private static event EventHandler<PrintingEventArgs> OnStartPrintEventHandler = delegate { };

        private static event EventHandler<PrintingEventArgs> OnFinishPrintEventHandler = delegate { };

        private static AbstractFactory _factory;
        private static IRepository _repository;
        private static ILogger _logger;

        static PrinterManager()
        {
            _factory = new Factory();
            _repository = new DynamicRepository();
            _logger = new Logger();

            OnStartPrintEventHandler += _logger.OnStartPrinting;
            OnFinishPrintEventHandler += _logger.OnFinishPrinting;
        }

        /// <summary>
        /// Method to add new <see cref="Printer"/> to repository.
        /// </summary>
        /// <param name="printer">
        /// Printer to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public static void Add(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }

            _repository.Add(printer);
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
        public static void Remove(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }

            _repository.Remove(printer);
        }

        /// <summary>
        /// Method to create new <see cref="Printer"/>
        /// </summary>
        /// <param name="name">
        /// Name of <see cref="Printer"/>
        /// </param>
        /// <param name="model">
        /// Model of <see cref="Printer"/>
        /// </param>
        /// <returns>
        /// New object of <see cref="Printer"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="name"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="model"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="name"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="model"/> is empty.
        /// </exception>
        public static Printer CreatePrinter(string name, string model)
        {
            if (name is null)
            {
                throw new ArgumentNullException("Printer's name can't be null");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Printer's name can't be empty.");
            }

            if (model is null)
            {
                throw new ArgumentNullException("Printer's model can't be null");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Printer's model can't be empty.");
            }

            return _factory.CreateCommonPrinter(name, model);
        }

        /// <summary>
        /// Method to get all elements of printers.
        /// </summary>
        /// <returns>
        /// List of <see cref="Printer"/>.
        /// </returns>
        public static List<Printer> GetList()
        {
            return _repository.ToList();
        }

        /// <summary>
        /// Method to print.
        /// </summary>
        /// <param name="printer">
        /// Printer.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public static void Print(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " printer object can't be null.");
            }

            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            var fileStream = File.OpenRead(fileDialog.FileName);

            var printerInfo = new PrintingEventArgs(printer, (int)fileStream.Length);
            OnStartPrintEventHandler(null, printerInfo);

            printer.Print(fileStream);

            OnFinishPrintEventHandler(null, printerInfo);
        }
    }
}