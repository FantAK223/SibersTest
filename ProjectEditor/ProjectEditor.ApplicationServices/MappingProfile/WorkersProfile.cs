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

/*            CreateMap<WorkersDTO, Workers>()
                 .ForMember(d => d.Projects, x => x.MapFrom<ProjectsResolver>())
                 ;*/

        }

/*        private class ProjectsResolver : IValueResolver<WorkersDTO, Workers, Projects>
        {
            public Projects Resolve(WorkersDTO source, Workers destination, Projects destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ProjectEditorDbContext>().Set<Projects>().Find(source.Projects.Id);
            }
        }*/
    }
}
