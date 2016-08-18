using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Scheduler.Cleaner.Interfaces;
using Scheduler.Cleaner.Model;
using Scheduler.Common.Enums;
using System.Collections.Generic;
using Scheduler.Service.Interfaces;

namespace Scheduler.Cleaner.Services
{
    public class AnalyseDirectoriesService : IAnalyseDirectoriesService
    {
        #region Fields

        private readonly IAnalysedDirectoryService analysedDirectoryService;

        #endregion Fields 

        #region Constructors

        public AnalyseDirectoriesService(IAnalysedDirectoryService analysedDirectoryService)
        {
            this.analysedDirectoryService = analysedDirectoryService;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Clean disposable files.
        /// </summary>
        /// <param name="analyzedDirectoryId">Analyzed directory id</param>
        public void CleanDisposableFiles(long analyzedDirectoryId)
        {
            var analyzedDirectory = analysedDirectoryService.GetAnalysedDirectoryById(analyzedDirectoryId);
            var analyzedDirectoryInfo = GetInformationOfDirectory(analyzedDirectory.Path, false); //TODO Add recursive flag to Database

            foreach (var enitity in analyzedDirectoryInfo.Childrens)
            {
                try
                {
                    if (enitity.LastAccessDate - enitity.CreatedDate < new TimeSpan(0, 1, 0))
                    {
                        if (enitity is AnalysedFileInfo)
                            File.Delete(enitity.FullPath);
                        else if (enitity is AnalysedDirectoryInfo)
                            ; //TODO Add dictionary deleting, 
                    }
                }
                catch (Exception)
                {

                    //Add exception handling.
                    throw new FieldAccessException();
                }

            }
        }

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="path">Path to specified directory.</param>
        /// <param name="recursive">Specifies if the info about kids of this directory should be collected.</param>
        /// <returns>AnalysedDirectory.</returns>
        public AnalysedDirectoryInfo GetInformationOfDirectory(string path, bool recursive = false)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                return GetInformationOfDirectory(directoryInfo, recursive);
            }
            catch (Exception)
            {
                //Add exception handling.
                throw new DirectoryNotFoundException();
            }
        }

        /// <summary>
        /// Get information about specified directory.
        /// </summary>
        /// <param name="directoryInfo">Directory info.</param>
        /// <param name="recursive">Specifies if the info about kids of this directory should be collected.</param>
        /// <returns>AnalysedDirectory.</returns>
        public AnalysedDirectoryInfo GetInformationOfDirectory(DirectoryInfo directoryInfo, bool recursive = false)
        {
            try
            {
                var AnalysedDirectory = new AnalysedDirectoryInfo
                {
                    Name = directoryInfo.Name,
                    FullPath = directoryInfo.FullName,
                    CreatedDate = directoryInfo.CreationTimeUtc,
                    LastAccessDate = directoryInfo.LastAccessTimeUtc,
                    LastWriteDate = directoryInfo.LastWriteTimeUtc,
                    Childrens = new List<AnalysedEntityInfo>(),
                };

                if (recursive)
                {
                    var AnalyseFilesService = new AnalyseFilesService();

                    List<AnalysedFileInfo> anlizedFiles = directoryInfo.GetFiles().ToList().Select(x => AnalyseFilesService.GetInformationOfFile(x)).ToList();

                    AnalysedDirectory.Childrens.AddRange(anlizedFiles);
                    AnalysedDirectory.Size += anlizedFiles.Sum(x => x.Size);

                    List<AnalysedDirectoryInfo> anlizedDirectories = directoryInfo.GetDirectories().ToList().Select(x => GetInformationOfDirectory(x, recursive)).ToList();
                    AnalysedDirectory.Childrens.AddRange(anlizedDirectories);
                    AnalysedDirectory.Size += anlizedDirectories.Sum(x => x.Size);
                }
                return AnalysedDirectory;
            }
            catch (Exception)
            {
                //TODO Add exception handling.
                throw new DirectoryNotFoundException();
            }
        }

        /// <summary>
        /// Gets the current path to the specified known directory as currently configured. This does
        /// not require the directory to be existent.
        /// </summary>
        /// <param name="knownDirectory">The known directory which current path will be returned.</param>
        /// <returns>The default path of the known directory.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path could not be retrieved.</exception>
        public string GetPathOfKnownDirectory(KnownDirectories knownDirectory)
        {
            return GetPathOfKnownDirectory(knownDirectory, false);
        }

        /// <summary>
        /// Gets the current path to the specified known directory as currently configured. This does
        /// not require the directory to be existent.
        /// </summary>
        /// <param name="knownDirectory">The known directory which current path will be returned.</param>
        /// <param name="defaultUser">Specifies if the paths of the default user will be used. This requires administrative rights.</param>
        /// <returns>The default path of the known directory.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path could not be retrieved.</exception>
        public string GetPathOfKnownDirectory(KnownDirectories knownDirectory, bool defaultUser)
        {
            return GetPathOfKnownDirectory(knownDirectory, KnowDirectoriesFlags.DontVerify, defaultUser);
        }

        #endregion Public methods

        #region Private methods

        private string GetPathOfKnownDirectory(KnownDirectories knownDirectory, KnowDirectoriesFlags flags,
            bool defaultUser)
        {
            IntPtr outPath;
            int result = SHGetKnownFolderPath(new Guid(knownDirectory.GetGuid()),
                (uint)flags, new IntPtr(defaultUser ? -1 : 0), out outPath);
            if (result >= 0)
            {
                return Marshal.PtrToStringUni(outPath);
            }
            else
            {
                //TODO Add exception handling.
                throw new ExternalException();
            }
        }

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        #endregion Private methods
    }
}