using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Method to add new <see cref="Printer"/> to repository.
        /// </summary>
        /// <param name="printer">
        /// Printer to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        void Add(Printer printer);

        /// <summary>
        /// Method to get information of repository.
        /// </summary>
        /// <param name="printer">
        /// Object to find.
        /// </param>
        /// <returns>
        /// If repository contains element then return true. Else false.
        /// </returns>
        bool Contains(Printer printer);

        /// <summary>
        /// Method to remove <see cref="Printer"/> from repository.
        /// </summary>
        /// <param name="printer">
        /// Printer to remove.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="printer"/> is null.
        /// </exception>
        void Remove(Printer printer);

        /// <summary>
        /// Method to get <see cref="List{Printer}"/> of repository.
        /// </summary>
        /// <returns>
        /// List of all elements.
        /// </returns>
        IReadOnlyCollection<Printer> GetPrinters();
    } 
}
