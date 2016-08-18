using System;
using System.Collections.Generic;
using Scheduler.Common.Enums;
using Scheduler.Tasks.Instances.Emails.Instances;

namespace Scheduler.Cleaner.Tasks
{
    /// <summary>
    /// Cleaner tasks factory class.
    /// </summary>
    public class CleanerFactory
    {
        /// <summary>
        /// Cleaner task (products) dictionary.
        /// </summary>
        private static Dictionary<AnalyseTypes, Func<CleanerTask>> cleanerTasksFactories = new Dictionary<AnalyseTypes, Func<CleanerTask>>()
        {
            { AnalyseTypes.CleanDisposableFiles, () => new CleanDisposableFiles() },
        };

        /// <summary>
        /// Gets cleaner task by type.
        /// </summary>
        /// <param name="type">Type of Analyse.</param>
        /// <returns><see cref="CleanerTask"/>Task instance.</returns>
        public static CleanerTask GetTask(AnalyseTypes type)
        {
            return cleanerTasksFactories[type]();
        }
    }
}
