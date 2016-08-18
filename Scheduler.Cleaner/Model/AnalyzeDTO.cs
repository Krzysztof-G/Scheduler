using Scheduler.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Cleaner.Model
{
    /// <summary>
    /// Analyze DTO
    /// </summary>
    public class AnalyzeDTO
    {
        /// <summary>
        /// Initialize a new instance of <see cref="AnalyzeDTO"/> class.
        /// </summary>
        public AnalyzeDTO()
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="AnalyzeDTO"/> class.
        /// </summary>
        /// <param name="type">Type of analyze</param>
        /// <param name="relatedObjectId">Related object id.</param>
        public AnalyzeDTO(AnalyseTypes type, long relatedObjectId)
        {
            Type = type;
            RelatedObjectId = relatedObjectId;
        }

        public AnalyseTypes Type { get; set; }
        public long RelatedObjectId { get; set; }
    }
}
