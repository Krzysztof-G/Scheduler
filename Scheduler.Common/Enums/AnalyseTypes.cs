using System.ComponentModel;

namespace Scheduler.Common.Enums
{
    /// <summary>
    /// Analise types
    /// </summary>
    public enum AnalyseTypes
    {
        CleanDisposableFiles = 1,
        CreateDailyDirectories = 2,
    }

    public static class AnaliseTypesExtensions
    {
        public static AnalyseTypes ToAnalyseTypes(this ScheduledTaskTypes source)
        {
            switch (source)
            {
                case ScheduledTaskTypes.CleanDisposableFiles:
                    return AnalyseTypes.CleanDisposableFiles;
                case ScheduledTaskTypes.CreateDailyDirectories:
                    return AnalyseTypes.CreateDailyDirectories;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
