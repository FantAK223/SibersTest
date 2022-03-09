using AutoMapper;
using ProjectEditor.Domain.Entities;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.ApplicationServices.MappingProfile
{
    public sealed class ProjectsProfile : Profile
    {
        public ProjectsProfile()
        {
            CreateMap<Projects, ProjectsDTO>()
                ;

           /* CreateMap<ProjectsDTO, Projects>()
                .ForMember(d => d.Workers, x => x.MapFrom<WorkersResolver>())
                ;*/
        }
/*
        private class WorkersResolver : IValueResolver<ProjectsDTO, Projects, Workers>
        {
            public Workers Resolve(ProjectsDTO source, Projects destination, Workers destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ProjectEditorDbContext>().Set<Workers>().Find(source.Workers.Id);
            }
        }*/
    }
}
