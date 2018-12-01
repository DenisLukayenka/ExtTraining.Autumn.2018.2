//-----------------------------------------------------------------------
// <copyright file="FakeRepository.cs" company="Dream Solution">
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

namespace No8.Solution.Repository
{
    /// <summary>
    /// Class to represent dynamic repository.
    /// </summary>
    public class FakeRepository : IRepository
    {
        /// <summary>
        /// Collection of printers.
        /// </summary>
        private List<Printer> printers;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeRepository"/> class.
        /// </summary>
        public FakeRepository()
        {
            this.printers = new List<Printer>();
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
                throw new ArgumentNullException(nameof(printer) + " can't be null.");
            }

            if (!this.Contains(printer))
            {
                this.printers.Add(printer);
            }
        }

        /// <summary>
        /// Method to get information of repository.
        /// </summary>
        /// <param name="printer">
        /// Object to find.
        /// </param>
        /// <returns>
        /// If repository contains element then return true. Else false.
        /// </returns>
        public bool Contains(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer) + " can't be null.");
            }

            return this.printers.Contains(printer);
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
                throw new ArgumentNullException(nameof(printer) + " can't be null.");
            }

            this.printers.Remove(printer);
        }

        /// <summary>
        /// Method to get <see cref="List{Printer}"/> of repository.
        /// </summary>
        /// <returns>
        /// List of all elements.
        /// </returns>
        public IReadOnlyCollection<Printer> GetPrinters()
        {
            return this.printers;
        }
    }
}
