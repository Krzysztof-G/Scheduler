using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Cleaner.Model
{
    public class AnalysedDirectoryInfo : AnalysedEntityInfo
    {
        public List<AnalysedEntityInfo> Childrens { get; set; }
    }
}
