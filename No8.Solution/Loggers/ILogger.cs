using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Loggers
{
    /// <summary>
    /// Interface to logging file.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Method to log <param name="message"/>.
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        void OnStartPrinting(object sender, EventArgs args);

        void OnFinishPrinting(object sender, EventArgs args);
    }
}
