using System;
using System.Collections.Generic;
using System.IO;

namespace No8.Solution.Printers
{
    /// <summary>
    /// Abstract class to represent printer.
    /// </summary>
    public abstract class Printer : IEquatable<Printer>
    {
        private string _name;
        private string _model;

        /// <summary>
        /// Name of printer.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is empty.
        /// </exception>
        public string Name
        {
            get => _name;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Printer's name can't be null");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Printer's name can't be empty.");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Model of printer.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is empty.
        /// </exception>
        public string Model
        {
            get => _model;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Printer's model can't be null");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Printer's model can't be empty.");
                }

                _model = value;
            }
        }

        public abstract void Print(FileStream fs);

        public bool Equals(Printer other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other) + " can't compare printer with null.");
            }

            return this.Name == other.Name && this.Model == other.Model;
        }
    }
}