//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Dream Solution">
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

namespace No8.Solution.Loggers
{
    /// <summary>
    /// Logger class.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Path to log file.
        /// </summary>
        private string logFileName;

        /// <summary>
        /// Default path to log file.
        /// </summary>
        private string defaultLogFile = @"E:\log.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logFileName">
        /// Path to logFile.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="logFileName"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="logFileName"/> is empty.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when <paramref name="logFileName"/> is not valid.
        /// </exception>
        public Logger(string logFileName)
        {
            if (logFileName is null)
            {
                throw new ArgumentNullException(nameof(logFileName) + " name of file can't be null.");
            }

            if (string.IsNullOrWhiteSpace(logFileName))
            {
                throw new ArgumentException(nameof(logFileName) + " name of file can't be empty.");
            }

            if (!File.Exists(logFileName))
            {
                throw new FileNotFoundException(nameof(logFileName) + ", can't find file.");
            }

            this.logFileName = logFileName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.logFileName = this.defaultLogFile;
        }

        /// <summary>
        /// Method to log.
        /// </summary>
        /// <param name="message">
        /// Message to be logging.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="message"/>  is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="message"/> is empty.
        /// </exception>
        public void Log(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message) + ". Message can't be null.");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(nameof(message) + ". Message can't be empty.");
            }

            using (TextWriter writer = File.AppendText(this.logFileName))
            {
                writer.Write(message);
                writer.WriteLine();
            }
        }
    }
}
