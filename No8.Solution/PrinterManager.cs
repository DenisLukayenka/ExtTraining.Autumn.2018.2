using System;
using System.Collections.Generic;
using System.IO;
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
        private IRepository _repository;
        private ILogger _logger;

        private static readonly Lazy<PrinterManager> instance =
            new Lazy<PrinterManager>(() => new PrinterManager());

        public static PrinterManager Instance => instance.Value;

        private PrinterManager() : this(new Logger(), new FakeRepository())
        {
        }

        private PrinterManager(ILogger logger, IRepository repository)
        {
            _repository = repository;
            _logger = logger;
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
        public void Add(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }

            if (_repository.Contains(printer))
            {
                throw new InvalidOperationException($"Printer {printer} is already exist.");
            }

            printer.startPrint += (sender, args) =>
                _logger.Log($"Printer {args.Name} {args.Model} start printing at {args.Time}.");

            printer.finishPrint += (sender, args) =>
                _logger.Log($"Printer {args.Name} {args.Model} finish printing at {args.Time}.");

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
        public void Remove(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " object can't be null.");
            }



            _repository.Remove(printer);
        }

        /// <summary>
        /// Method to get all elements of printers.
        /// </summary>
        /// <returns>
        /// List of <see cref="Printer"/>.
        /// </returns>
        public IReadOnlyCollection<Printer> GetList() => _repository.GetPrinters();

        /// <summary>
        /// Method to print.
        /// </summary>
        /// <param name="printer">
        /// Printer.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        public void Print(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " printer object can't be null.");
            }

            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            var fileStream = File.OpenRead(fileDialog.FileName);

            printer.Print(fileStream);
        }
    }
}