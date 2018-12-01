//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Dream Solution">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Denis Lukayenka</author>
//-----------------------------------------------------------------------

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
        /// <param name="message">
        /// Message to log.
        /// </param>
        void Log(string message);
    }
}
