using System.IO;
using Scheduler.Cleaner.Model;
using Scheduler.Common.Enums;

namespace Scheduler.Cleaner.Interfaces
{
    public interface IAnalyseDirectoriesService
    {
        /// <summary>
        /// Clean disposable files.
        /// </summary>
        /// <param name="analyzedDirectoryId">Analyzed directory id</param>
        void CleanDisposableFiles(long analyzedDirectoryId);

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="path">Path to specified directory.</param>
        /// <param name="recursive">Specifies if the info about kids of this directory should be collected.</param>
        /// <returns>AnalysedDirectoryInfo.</returns>
        AnalysedDirectoryInfo GetInformationOfDirectory(string path, bool recursive = false);

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="directoryInfo">Directory info.</param>
        /// <param name="recursive">Specifies if the info about kids of this directory should be collected.</param>
        /// <returns>AnalysedDirectoryInfo.</returns>
        AnalysedDirectoryInfo GetInformationOfDirectory(DirectoryInfo directoryInfo, bool recursive = false);

        /// <summary>
        /// Gets the current path to the specified known directory as currently configured. This does
        /// not require the directory to be existent.
        /// </summary>
        /// <param name="knownDirectory">The known directory which current path will be returned.</param>
        /// <returns>The default path of the known directory.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path could not be retrieved.</exception>
        string GetPathOfKnownDirectory(KnownDirectories knownDirectory);

        /// <summary>
        /// Gets the current path to the specified known directory as currently configured. This does
        /// not require the directory to be existent.
        /// </summary>
        /// <param name="knownDirectory">The known directory which current path will be returned.</param>
        /// <param name="defaultUser">Specifies if the paths of the default user will be used. This requires administrative rights.</param>
        /// <returns>The default path of the known directory.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path could not be retrieved.</exception>
        string GetPathOfKnownDirectory(KnownDirectories knownDirectory, bool defaultUser);
    }
}
