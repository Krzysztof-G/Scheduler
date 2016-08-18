using Scheduler.Common.Enums;

namespace Scheduler.Service.Models
{
    /// <summary>
    /// Analysed directory DTO
    /// </summary>
    public class AnalysedDirectoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public AnalyseTypes AnalyseType { get; set; }
    }
}
