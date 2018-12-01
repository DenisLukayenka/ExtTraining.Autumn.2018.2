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
        private string _logFileName;
        private string _defaultLogFile = "log.txt";

        /// <summary>
        /// Constructor to create new log object.
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

            _logFileName = logFileName;
        }

        /// <summary>
        /// Constructor to create log object with default path to log file.
        /// </summary>
        public Logger()
        {
            _logFileName = _defaultLogFile;
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

            using (TextWriter writer = File.AppendText(_logFileName))
            {
                writer.Write(message);
                writer.WriteLine();
            }
        }
    }
}
