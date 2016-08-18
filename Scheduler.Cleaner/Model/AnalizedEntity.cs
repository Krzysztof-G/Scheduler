using System;

namespace Scheduler.Cleaner.Model
{
    public abstract class AnalysedEntityInfo
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public DateTime? LastWriteDate { get; set; }
        public long Size { get; set; }
    }
}
