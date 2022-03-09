using AutoMapper;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.Domain.Entities;
using ProjectEditor.Domain.Entities.SharedKarnel;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.ApplicationServices.MappingProfile
{
    public sealed class ProjectWorkerProfile : Profile
    {
        public ProjectWorkerProfile()
        {
            CreateMap<ProjectWorker, ProjectWorkerDTO>()
                ;

           /* CreateMap<ProjectWorkerDTO, ProjectWorker>()
                .ForMember(d => d.Projects, x => x.MapFrom<ProjectsResolver>())
                .ForMember(d => d.Workers, x => x.MapFrom<WorkersResolver>())
                ;*/
        }
/*
        private class ProjectsResolver : IValueResolver<ProjectWorkerDTO, ProjectWorker, Projects>
        {
            public Projects Resolve(ProjectWorkerDTO source, ProjectWorker destination, Projects destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ProjectEditorDbContext>().Set<Projects>().Find(source.Projects.Id);
            }
        }

        private class WorkersResolver : IValueResolver<ProjectWorkerDTO, ProjectWorker, Workers>
        {
            public Workers Resolve(ProjectWorkerDTO source, ProjectWorker destination, Workers destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ProjectEditorDbContext>().Set<Workers>().Find(source.Workers.Id);
            }
        }*/
    }
}
