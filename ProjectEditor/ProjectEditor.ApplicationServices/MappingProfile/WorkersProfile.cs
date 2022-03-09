using AutoMapper;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.Domain.Entities;
using ProjectEditor.Domain.Entities.SharedKarnel;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.ApplicationServices.MappingProfile
{
    public sealed class WorkersProfile : Profile
    {
        public WorkersProfile()
        {
            CreateMap<Workers, WorkersDTO>()
                ;
/*
           CreateMap<WorkersDTO, Workers>()
                .ForMember(d => d.ProjectWorker, x => x.MapFrom<ProjectWorkerResolver>())
                ;*/

        }

        /*private class ProjectWorkerResolver : IValueResolver<WorkersDTO, Workers, ProjectWorker>
        {
            public ProjectWorker Resolve(WorkersDTO source, Workers destination, ProjectWorker destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ProjectEditorDbContext>().Set<ProjectWorker>().Find(source.ProjectWorker.Id);
            }
        }*/
    }
}
