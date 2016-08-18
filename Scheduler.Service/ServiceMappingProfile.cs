using AutoMapper;
using Schdeuler.Repository;
using Scheduler.Common.Enums;
using Scheduler.Service.Models;

namespace Scheduler.Service
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            AnalyseMapping();
            UserMapping();
            SchedulerMapping();
        }

        private void AnalyseMapping()
        {
            CreateMap<AnalysedDirectory, AnalysedDirectoryDTO>()
                .ForMember(d => d.AnalyseType, o => o.MapFrom(s => (AnalyseTypes)s.AnalyseTypeId));
        }

        private void UserMapping()
        {
            CreateMap<User, UserDTO>();
        }

        private void SchedulerMapping()
        {
            CreateMap<ScheduledTask, ScheduledTaskDTO>()
            .ForMember(d => d.ScheduledTaskType, o => o.MapFrom(s => (ScheduledTaskTypes)s.ScheduledTaskTypeId))
            .ForMember(d => d.ScheduledTaskState, o => o.MapFrom(s => (ScheduledTaskStates)s.ScheduledTaskStateId));
        }
    }
}
