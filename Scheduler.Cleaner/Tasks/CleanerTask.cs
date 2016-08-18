using Autofac;
using Scheduler.Cleaner.Helpers.DependencyInjection;
using Scheduler.Cleaner.Model;
using Scheduler.Common.Enums;
using Scheduler.Service.Interfaces;

namespace Scheduler.Cleaner.Tasks
{
    /// <summary>
    /// Email class
    /// </summary>
    public abstract class CleanerTask
    {
        /// <summary>
        /// Analyse Directory service instance.
        /// </summary>
        protected IAnalysedDirectoryService AnalysedDirectoryService;

        /// <summary>
        /// Initialize a new instance of <see cref="CleanerTask"/> class.
        /// </summary>
        public CleanerTask()
        {
            AnalysedDirectoryService = Resolver.Container.Resolve<IAnalysedDirectoryService>();
        }

        /// <summary>
        /// Analise type.
        /// </summary>
        public abstract AnalyseTypes Type { get; }

        /// <summary>
        /// Analyze something.
        /// </summary>
        /// <param name="analyze">Analyze</param>
        public abstract void Analyze(AnalyzeDTO analyze);
    }
}