using AutoMapper;
using Schdeuler.Repository;
using Schdeuler.Repository.Interfaces;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;
using System.Linq;

namespace Scheduler.Service.Services
{
    /// <summary>
    /// Analused directory service instance.
    /// </summary>
    public class AnalysedDirectoryService : IAnalysedDirectoryService
    {
        private IAnalysedDirectoryRepository repository;

        public AnalysedDirectoryService(IAnalysedDirectoryRepository repository)
        {
            this.repository = repository;
        }

        public AnalysedDirectoryDTO GetAnalysedDirectoryById(long analysedDirectoryId)
        {
            AnalysedDirectory analysedDirectory = repository.FindBy(a => a.Id == a.Id).FirstOrDefault();
            return Mapper.Map<AnalysedDirectoryDTO>(analysedDirectory);
        }
    }
}
