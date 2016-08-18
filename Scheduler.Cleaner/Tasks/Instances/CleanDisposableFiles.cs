using System;
using Scheduler.Cleaner.Model;
using Scheduler.Cleaner.Tasks;
using Scheduler.Common.Enums;
using Scheduler.Cleaner.Interfaces;
using Scheduler.Cleaner.Helpers.DependencyInjection;
using Autofac;

namespace Scheduler.Tasks.Instances.Emails.Instances
{
    public class CleanDisposableFiles : CleanerTask
    {
        private readonly IAnalyseDirectoriesService analyseDirectoriesService;

        public CleanDisposableFiles()
        {
            this.analyseDirectoriesService = Resolver.Container.Resolve<IAnalyseDirectoriesService>();
        }

        public override AnalyseTypes Type
        {
            get
            {
                return AnalyseTypes.CleanDisposableFiles;
            }
        }

        public override void Analyze(AnalyzeDTO analyze)
        {
            analyseDirectoriesService.CleanDisposableFiles(analyze.RelatedObjectId);
        }
    }
}
