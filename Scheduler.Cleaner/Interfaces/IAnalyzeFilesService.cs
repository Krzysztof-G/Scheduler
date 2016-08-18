using Scheduler.Cleaner.Model;
using System.IO;

namespace Scheduler.Cleaner.Interfaces
{
    public interface IAnalyseFilesService
    {
        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="path">Path to specified directory.</param>
        /// <returns>AnalysedFileInfo.</returns>
        AnalysedFileInfo GetInformationOfFile(string path);

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="fileInfo">File info.</param>
        /// <returns>AnalysedFileInfo.</returns>
        AnalysedFileInfo GetInformationOfFile(FileInfo fileInfo);

    }
}
