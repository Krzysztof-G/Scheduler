using Scheduler.Cleaner.Interfaces;
using Scheduler.Cleaner.Model;
using System.IO;

namespace Scheduler.Cleaner.Services
{
    public class AnalyseFilesService : IAnalyseFilesService
    {
        #region Public methods

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="path">Path to specified directory.</param>
        /// <returns>AnalysedFileInfo.</returns>
        public AnalysedFileInfo GetInformationOfFile(string path)
        {
            try
            {
                var fileInfo = new FileInfo(path);
                return GetInformationOfFile(fileInfo);
            }
            catch (System.Exception)
            {
                //TODO Add exception handling.
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="fileInfo">File info.</param>
        /// <returns>AnalysedFileInfo.</returns>
        public AnalysedFileInfo GetInformationOfFile(FileInfo fileInfo)
        {
            try
            {
                var AnalysedFile = new AnalysedFileInfo
                {
                    Name = fileInfo.Name,
                    FullPath = fileInfo.FullName,
                    Extension = fileInfo.Extension,
                    CreatedDate = fileInfo.CreationTimeUtc,
                    LastAccessDate = fileInfo.LastAccessTimeUtc,
                    LastWriteDate = fileInfo.LastWriteTimeUtc,
                    Size = fileInfo.Length,
                };

                return AnalysedFile;
            }
            catch (System.Exception)
            {
                //TODO Add exception handling.
                throw new FileNotFoundException();
            }
        }

        #endregion Public methods
    }
}
