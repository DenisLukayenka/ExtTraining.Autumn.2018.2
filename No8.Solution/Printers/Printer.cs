//-----------------------------------------------------------------------
// <copyright file="Printer.cs" company="Dream Solution">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Denis Lukayenka</author>
//-----------------------------------------------------------------------

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
        /// <summary>
        /// Field with info about name of printer.
        /// </summary>
        private string name;

        /// <summary>
        /// Field with info about model of printer.
        /// </summary>
        private string model;

        /// <summary>
        /// Event of start printing.
        /// </summary>
        public event EventHandler<PrintEventArgs> StartPrint = delegate { };

        /// <summary>
        /// Event of finish printing.
        /// </summary>
        public event EventHandler<PrintEventArgs> FinishPrint = delegate { };

        /// <summary>
        /// Gets or sets name of printer.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is empty.
        /// </exception>
        public string Name
        {
            get => this.name;
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

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets model of printer.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is empty.
        /// </exception>
        public string Model
        {
            get => this.model;
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

                this.model = value;
            }
        }

        /// <summary>
        /// Main method to print.
        /// </summary>
        /// <param name="stream">
        /// Stream to write.
        /// </param>
        public void Print(Stream stream)
        {
            this.OnStartPrint();

            this.PrintLogic(stream);

            this.OnFinishPrint();
        }

        /// <summary>
        /// Method to get hash code of instance.
        /// </summary>
        /// <returns>
        /// Hash code of instance.
        /// </returns>
        public override int GetHashCode()
        {
            int hash;
            unchecked
            {
                hash = this.Name.GetHashCode() + this.Model.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Method to compare two instances of <see cref="Printer"/> class.
        /// </summary>
        /// <param name="other">
        /// Printer to compare.
        /// </param>
        /// <returns>
        /// Result of comparison.
        /// </returns>
        public bool Equals(Printer other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other) + " can't compare printer with null.");
            }

            return this.Name == other.Name && this.Model == other.Model;
        }

        /// <summary>
        /// Logic of print method.
        /// </summary>
        /// <param name="stream">
        /// Stream to write.
        /// </param>
        protected abstract void PrintLogic(Stream stream);

        /// <summary>
        /// Method to perform on event.
        /// </summary>
        protected virtual void OnStartPrint() => this.StartPrint?.Invoke(this, new PrintEventArgs(this.Name, this.Model));

        /// <summary>
        /// Method to perform on event.
        /// </summary>
        protected virtual void OnFinishPrint() => this.FinishPrint?.Invoke(this, new PrintEventArgs(this.Name, this.Model));

        /// <summary>
        /// Class with info about event.
        /// </summary>
        public class PrintEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PrintEventArgs"/> class.
            /// </summary>
            /// <param name="name">
            /// Name of printer.
            /// </param>
            /// <param name="model">
            /// Model of printer
            /// </param>
            public PrintEventArgs(string name, string model)
            {
                this.Name = name;
                this.Model = model;
                this.Time = DateTime.Now.TimeOfDay;
            }

            /// <summary>
            /// Gets or sets name of printer.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets model of printer.
            /// </summary>
            public string Model { get; set; }

            /// <summary>
            /// Gets or sets time of working.
            /// </summary>
            public TimeSpan Time { get; set; }
        }
    }
}